namespace _Scripts.SaveSystem2.SaveManagement
{
	using _Scripts.SaveSystem2.SaveData;

	public interface ISaveManager
	{
		GameSaveData GameSaveData { get; }
		PreferencesData PrefsData { get; }
		void SaveData();
		void SavePrefs();
	}
}