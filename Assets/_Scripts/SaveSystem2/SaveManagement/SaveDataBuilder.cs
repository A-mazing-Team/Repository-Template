namespace _Scripts.SaveSystem2.SaveManagement
{
	using _Scripts.SaveSystem2.SaveData;

	public class SaveDataBuilder
	{
		private GameSaveData _saveData;


		public SaveDataBuilder Create()
		{
			_saveData = new GameSaveData();
			return this;
		}


		public SaveDataBuilder Set( GameSaveData saveData )
		{
			_saveData = saveData;
			return this;
		}


		public GameSaveData GetData()
		{
			GameSaveData saveData = _saveData;
			_saveData = null;
			
			return saveData;
		}

		public SaveDataBuilder FixIssues()
		{
			return this;
		}
	}
}

