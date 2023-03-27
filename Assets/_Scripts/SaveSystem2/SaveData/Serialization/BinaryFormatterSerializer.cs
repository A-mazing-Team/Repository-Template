namespace _Scripts.SaveSystem2.SaveData.Serialization
{
	using System;

	public class BinaryFormatterSerializer : ISerializer
	{
		public byte[] SerializeBinary( object obj )
		{
			return LocalSaveUtility.SerializeToBytes( obj );
		}

		public object DeserializeBinary( byte[] bytes )
		{
			return LocalSaveUtility.Deserialize< object >( bytes );
		}

		public string SerializeJSON<T>( T obj )
		{
			throw new InvalidOperationException("JSON serialize not supported");
		}

		public T DeserializeJSON<T>( string json )
		{
			throw new InvalidOperationException( "JSON serialize not supported" );
		}
	}
}

