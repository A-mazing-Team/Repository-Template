namespace _Scripts.LevelsManagement2
{
	using System;
	using _Scripts.SaveSystem2.SaveManagement;
	using UnityEngine;
	using UnityEngine.SceneManagement;
	using UnityEngine.UI;
	using Zenject;

	public class ScenesManager : IInitializable, IDisposable
	{
	#pragma warning disable 0649

		[Inject] private ISaveManager _saveManager;
		[Inject] private LevelScenesConfig _levelScenesConfig;
		
	#pragma warning restore 0649

		/*private readonly CompositeDisposable _lifetimeDisposables = new CompositeDisposable();
		private readonly BoolReactiveProperty _isLevelLoaded = new BoolReactiveProperty();

		private int LevelNumber => _saveManager.GameSaveData.LevelNumber.Value;

		public IObservable<Unit> LevelLoaded
		{
			get
			{
				return _isLevelLoaded
					.Where( v => v )
					.Select( v => Unit.Default );
			}
		}*/

		public void Initialize()
		{
			#if UNITY_EDITOR
			UnloadAlreadyLoadedLevelsScenes();
			#endif
		}

		public void Dispose()
		{
			//_lifetimeDisposables.Clear();
		}

		private void UnloadAlreadyLoadedLevelsScenes()
		{
			/*_levelScenesConfig.Levels
				.Where( scene => SceneManager.GetSceneByName( scene.SceneName ).isLoaded )
				.ForEach( scene => UnloadScene(scene.SceneName) );*/
		}

		public void LoadLevelScene()
		{
			var levelSceneName = GetCurrentLevelSceneName();
			var isAlreadyLoaded = SceneManager.GetSceneByName( levelSceneName ).isLoaded;

			Debug.Log( $"LOAD LEVEL SCENE : {levelSceneName}, already loaded : {isAlreadyLoaded}" );

			if ( isAlreadyLoaded )
				return;
			
			LoadScene( levelSceneName );

			/*Observable
				.NextFrame()
				.Subscribe( _ => SetLevelLoadedState( true ) )
				.AddTo( _lifetimeDisposables );*/
		}

		public void UnloadLevelScene()
		{
			SetLevelLoadedState( false );
		}

		private void SetLevelLoadedState( bool v )
		{
			//_isLevelLoaded.Value = v;

			if ( v ) 
				SetActiveScene();
			else
			{
				UnloadScene( GetCurrentLevelSceneName() );
				//UnloadAlreadyLoadedLevelsScenes();
			}
		}

		private void SetActiveScene()
		{
			var currentScene = SceneManager.GetSceneByName( GetCurrentLevelSceneName() );
			SceneManager.SetActiveScene( currentScene );
		}

		private string GetCurrentLevelSceneName()
		{
			var levelScene = _levelScenesConfig.UseOverride 
				? _levelScenesConfig.OverrideLevel 
				: _levelScenesConfig.Levels[GetLevelSceneIndex()];
			
			return levelScene.SceneName;
		}

		private int GetLevelSceneIndex()
		{
			//return (LevelNumber - 1) % _levelScenesConfig.Levels.Count;
			return 0;
		}

		private void LoadScene( string sceneName )
		{
			SceneManager.LoadScene( sceneName, LoadSceneMode.Additive );
		}

		private void UnloadScene( string sceneName )
		{
			var scene = SceneManager.GetSceneByName( sceneName );

			if ( scene.isLoaded == false )
			{
				Debug.LogWarning( $"Unload is ignored because scene {sceneName} is not loaded" );
				return;
			}

			SceneManager.UnloadSceneAsync( sceneName );
		}
	}
}

