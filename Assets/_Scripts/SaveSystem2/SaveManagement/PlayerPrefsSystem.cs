namespace _Scripts.SaveSystem2.SaveManagement
{
	using _Scripts.SaveSystem2.SaveData;
	using UnityEngine;
	using Zenject;

	public class PlayerPrefsSystem
	{
		[Inject] private SaveSettings _saveSettings;
		
		private const string PreferencesKey = "Preferences";


		public PreferencesData Load()
		{
			PreferencesData loadData;
			var exist = PlayerPrefs.HasKey( PreferencesKey );

			Debug.Log( $"PlayerPrefs is exist : {exist}" );
			
			if ( exist )
			{
				var json = PlayerPrefs.GetString( PreferencesKey );
				loadData = JsonUtility.FromJson<PreferencesData>( json );
			}
			else
			{
				loadData = CreateNew();
			}

			return loadData;
		}

		public PreferencesData CreateNew()
		{
			return new PreferencesData()
			{
				IsFirstLaunch = true,
				SoundEnabled = _saveSettings.SoundOnDefault,
				VibrateEnabled = _saveSettings.VibrateOnDefault
			};
		}


		public void Save( PreferencesData data )
		{
			var json = JsonUtility.ToJson( data );
			PlayerPrefs.SetString( PreferencesKey, json );
		}


		#if UNITY_EDITOR
		public void DeletePlayerPrefs()
		{
			PlayerPrefs.DeleteAll();
		}
		#endif
	}
}

