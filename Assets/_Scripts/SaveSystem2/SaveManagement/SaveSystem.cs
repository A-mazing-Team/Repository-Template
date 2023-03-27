namespace _Scripts.SaveSystem2.SaveManagement
{
	using System.IO;
	using _Scripts.SaveSystem2.SaveData;
	using _Scripts.SaveSystem2.SaveData.Serialization;
	using UnityEngine;
	using Zenject;

	public class SaveSystem
	{
		private const string SaveName = "data";
		private static string SaveFilePath => LocalSaveUtility.MakePersistentFilePath( SaveName );


		[Inject] private ISerializer _serializer;

		public bool Load( out GameSaveData data )
		{
			try
			{
				byte[] bytes = LocalSaveUtility.LoadFile( SaveFilePath );
				data = (GameSaveData) _serializer.DeserializeBinary( bytes );
			}
			catch
			{
				data = null;
			}

			return data != null;
		}


		public void Save( GameSaveData data )
		{
			byte[] bytes = _serializer.SerializeBinary( data );

			LocalSaveUtility.SaveFile( SaveFilePath, bytes );
		}

		public void DeleteSaveFile()
		{
			var exist = File.Exists( SaveFilePath );
			Debug.Log( $"Save file is exist : {exist}"  );
			
			if ( exist )
				File.Delete( SaveFilePath );
		}
	}
}

