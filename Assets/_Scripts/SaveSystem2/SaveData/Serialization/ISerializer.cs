namespace _Scripts.SaveSystem2.SaveData.Serialization
{
	public interface ISerializer
	{
		byte[] SerializeBinary( object obj );
		object DeserializeBinary( byte[] bytes );
		string SerializeJSON<T>( T obj );
		T DeserializeJSON<T>( string json );
	}
}
