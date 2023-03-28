namespace _Scripts.SaveSystem2.SaveData.Serialization
{
	using Sirenix.Serialization;

	public class OdinSerializer : ISerializer
	{
		public byte[] SerializeBinary( object obj )
		{
		    var context = new SerializationContext();

			return SerializationUtility.SerializeValue( obj, DataFormat.Binary, context );
		}


		public object DeserializeBinary( byte[] bytes )
		{
		    var context = new DeserializationContext();

			return SerializationUtility.DeserializeValue<object>( bytes, DataFormat.Binary, context );
		}


		public string SerializeJSON<T>( T obj )
		{
			var context = new SerializationContext();
			var buffer = SerializationUtility.SerializeValue<T>( obj, DataFormat.JSON, context );
			var json = System.Text.Encoding.UTF8.GetString( buffer, 0, buffer.Length );
			
			return json;
		}


		public T DeserializeJSON<T>( string json )
		{
			var context = new DeserializationContext();
			var buffer = System.Text.Encoding.UTF8.GetBytes( json );
			var obj = SerializationUtility.DeserializeValue<T>( buffer, DataFormat.JSON, context );

			return obj;
		}
	}
}

