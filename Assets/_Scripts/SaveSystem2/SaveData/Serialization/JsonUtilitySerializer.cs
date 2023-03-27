namespace _Scripts.SaveSystem2.SaveData.Serialization
{
	using System;
	using UnityEngine;

	public class JsonUtilitySerializer : ISerializer
	{
		public byte[] SerializeBinary( object obj )
		{
			throw new InvalidOperationException( "Binary serialize not supported" );
		}

		public object DeserializeBinary( byte[] bytes )
		{
			throw new InvalidOperationException( "Binary serialize not supported" );
		}

		public string SerializeJSON<T>( T obj )
		{
			return JsonUtility.ToJson( obj );
		}

		public T DeserializeJSON<T>( string json )
		{
			return JsonUtility.FromJson<T>( json );
		}
	}
}

