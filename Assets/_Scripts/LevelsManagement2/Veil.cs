namespace _Scripts.LevelsManagement2
{
	using System;
	using DG.Tweening;
	using UnityEngine;
	using UnityEngine.UI;
	using Zenject;

	public class Veil : MonoBehaviour
	{
		[Header( "Settings" )]
		[SerializeField] private float _duration;
		[SerializeField] private Ease _ease;
		[SerializeField] private Color _loadingLoopColor = Color.black;
		[SerializeField] private Color _loadingDefaultColor = Color.black;
		[SerializeField] private float _loadingDuration = 0.5f;

		[Header( "References" )]
		[SerializeField] private CanvasGroup _mainCanvasGroup;
		[SerializeField] private Image _loadingImage;

		[Inject] private ScenesManager _scenesManager;


		private Tween _mainTween;
		private Tween _loadingTween;

		private void Start()
		{
			/*_scenesManager.LevelLoaded
				//.Skip( 1 )
				.DelayFrame( 1 )
				.Where( _ => _mainCanvasGroup != null )
				.Subscribe( _ => Hide() )
				.AddTo( this );*/
			
			if(IsActive())
				StartLoadingAnimation();
		}


		public void Show( Action onComplete )
		{
			_loadingImage.color = _loadingDefaultColor;
			
			SetActive( true );
			TweenVeil( _mainCanvasGroup.alpha, 1, () =>
			{
				onComplete?.Invoke();
				StartLoadingAnimation();
			} );
		}


		public void Hide()
		{
			EndLoadingAnimation();
			TweenVeil( _mainCanvasGroup.alpha, 0, () => SetActive( false ) );
		}

		private void StartLoadingAnimation()
		{
			_loadingTween = _loadingImage
				.DOColor( _loadingLoopColor, _loadingDuration )
				.SetLoops( -1, LoopType.Yoyo );
		}

		private void EndLoadingAnimation()
		{
			_loadingTween?.Kill();

			_loadingTween = _loadingImage
				.DOColor( _loadingDefaultColor, _duration * 0.5f )
				.OnComplete( () => _loadingTween.Kill() );
		}


		private void TweenVeil( float from, float to, Action completeCallback )
		{
			_mainTween?.Kill();

			_mainTween = _mainCanvasGroup
				.DOFade( to, _duration )
				.From( from )
				.SetUpdate( true )
				.SetEase( _ease )
				.OnComplete( () =>
				{
					_mainTween = null;
					completeCallback.Invoke();
				} );
		}

		private void SetActive( bool state ) => _mainCanvasGroup.gameObject.SetActive( state );
		private bool IsActive() => _mainCanvasGroup.gameObject.activeSelf;

		//[Button]
		private void ShowTest() => Show( null );
		
		//[Button]
		private void HideTest() => Hide();
	}
}

