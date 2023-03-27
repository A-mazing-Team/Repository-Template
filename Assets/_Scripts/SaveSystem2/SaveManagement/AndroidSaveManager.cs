namespace _Scripts.SaveSystem2.SaveManagement
{
	using _Scripts.SaveSystem2.SaveData;
	using Zenject;

	public class AndroidSaveManager : ISaveManager, IInitializable
	{
	#pragma warning disable 0649

		[Inject] private SaveSystem _saveSystem;
		[Inject] private PlayerPrefsSystem _playerPrefsSystem;
		[Inject] private SaveDataBuilder _saveDataBuilder;
		[Inject] private SaveSettings _saveSettings;
		//[Inject] private GameState _gameState;

	#pragma warning restore 0649

		public void Initialize()
		{
			PlayerPrefsSetup();
			SaveDataSetup();
		}

		private void SaveDataSetup()
		{
			#if UNITY_EDITOR
			if ( _saveSettings.DeleteSaveWhenStartAtEditor )
				_saveSystem.DeleteSaveFile();
			#endif


			if ( PrefsData.IsFirstLaunch )
			{
				PrefsData.IsFirstLaunch = false;
				_playerPrefsSystem.Save( PrefsData );
				
				_saveSystem.DeleteSaveFile();
			}

			GameSaveData = LoadOrCreateNew();
		}

		private void PlayerPrefsSetup()
		{
			#if UNITY_EDITOR
			if ( _saveSettings.DeletePrefsWhenStartAtEditor )
				_playerPrefsSystem.DeletePlayerPrefs();
			#endif

			PrefsData = _playerPrefsSystem.Load();

			//_gameState.SoundEnabled.Value = PrefsData.SoundEnabled;
			//_gameState.VibrateEnabled.Value = PrefsData.VibrateEnabled;

			PlayerPrefsSubscribe();
		}

		public GameSaveData GameSaveData { get; private set; }

		public PreferencesData PrefsData { get; private set; }

		public void SaveData() => _saveSystem.Save( GameSaveData );

		public void SavePrefs() => _playerPrefsSystem.Save( PrefsData );


		private void PlayerPrefsSubscribe()
		{
			/*_gameState.SoundEnabled
				.Subscribe( v =>
				{
					PrefsData.SoundEnabled = v;
					SavePrefs();
				} )
				.AddTo( _disposables );

			_gameState.VibrateEnabled
				.Subscribe( v =>
				{
					PrefsData.VibrateEnabled = v;
					SavePrefs();
				} )
				.AddTo( _disposables );*/

		}

		private GameSaveData LoadOrCreateNew()
		{
			if ( _saveSystem.Load( out GameSaveData data ))
			{
				return _saveDataBuilder
					.Set( data )
					.FixIssues()
					.GetData();
			}
			else
			{
				return _saveDataBuilder
					.Create()
					.FixIssues()
					.GetData();
			}
		}
	}
}

