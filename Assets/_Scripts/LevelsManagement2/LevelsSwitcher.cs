namespace _Scripts.LevelsManagement2
{
	using _Scripts.SaveSystem2.SaveData;
	using _Scripts.SaveSystem2.SaveManagement;
	using UnityEngine;
	using Zenject;

	public class LevelsSwitcher : IInitializable
	{
		private const bool WithVeil = true;
		
		[Inject] private Veil _veil;
		[Inject] private ISaveManager _saveManager;
		[Inject] private ScenesManager _scenesManager;
		[Inject] private LevelScenesConfig _levelScenesConfig;
		

		private GameSaveData GameSaveData => _saveManager.GameSaveData;
		
		//private IntReactiveProperty LevelNumber => GameSaveData.LevelNumber;


		public void Initialize()
		{
			Debug.Log( "LevelsSwitcher Initialize" );
			_scenesManager.LoadLevelScene();
		}

		public void SwitchLevelBy( int delta, bool allowCycled = false )
		{
			if ( allowCycled )
				GotoLevel( CycledLevelNumber( delta ), WithVeil );
			else
			{
				if ( !IsLevelBoundary( delta ) )
					GotoLevel( ClampedLevelNumber( delta ), WithVeil );
			}
		}


		public bool IsLevelBoundary( int delta )
		{
			//return LevelNumber.Value == ClampedLevelNumber( delta );
			return false;
		}


		public void RestartLevel()
		{
			//GotoLevel( LevelNumber.Value, WithVeil );
		}

		private void GotoLevel( int levelNumber, bool withVeil )
		{
			if(withVeil)
				_veil.Show( () => SwitchToLevel( levelNumber ) );
			else
				SwitchToLevel( levelNumber );
		}


		private void SwitchToLevel( int levelNumber )
		{
			_scenesManager.UnloadLevelScene();

			//LevelNumber.Value = levelNumber;
			_saveManager.SaveData();

			_scenesManager.LoadLevelScene();
		}

		private int ClampedLevelNumber( int delta )
		{
			//return Mathf.Clamp( LevelNumber.Value + delta, 1, _levelScenesConfig.Levels.Count );
			return 0;
		}

		private int CycledLevelNumber( int delta )
		{
			//return (LevelNumber.Value + delta + _levelScenesConfig.Levels.Count - 1) % _levelScenesConfig.Levels.Count + 1;
			return 0;
		}
	}
}

