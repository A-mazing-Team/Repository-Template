namespace _Scripts.SaveSystem2
{
	using System;
	using System.IO;
	using System.Reflection;
	using System.Runtime.Serialization;
	using System.Runtime.Serialization.Formatters.Binary;
	using JetBrains.Annotations;
	using UnityEngine;

	public static class LocalSaveUtility
	{
		public static string MakePersistentFilePath( string path )
		{
			const string tmpFileExt = ".dat";

			return Path.Combine( Application.persistentDataPath, path + tmpFileExt );
		}


		public static byte[] LoadFile( string filePath )
		{
			if ( !File.Exists( filePath ) )
				throw new Exception( $"File {filePath} not exist" );

			byte[] data;
			
			using ( var fs = File.OpenRead( filePath ) )
			{
				data = new byte[fs.Length];
				fs.Read( data, 0, data.Length );
			}

			return data;
		}


		public static void SaveFile( string filePath, byte[] data )
		{
			string directory = Path.GetDirectoryName( filePath );
			
			if ( directory == null )
				throw new Exception( $"Can't get directory from {filePath}" );

			if ( File.Exists( filePath ) ) 
				File.Delete( filePath );

			Directory.CreateDirectory( directory );

			using ( var fs = File.OpenWrite( filePath ) )
			{
				fs.Write( data, 0, data.Length );
			}
		}


		public static byte[] SerializeToBytes( object obj )
		{
			var bf = new BinaryFormatter();
			var ms = new MemoryStream();

			try
			{
				bf.Serialize( ms, obj );
			}
			catch ( Exception e )
			{
				Debug.LogWarning( e );
			}

			return ms.ToArray();
		}


		[CanBeNull]
		public static T Deserialize<T>( byte[] arrBytes, bool useStringAssembly = true, T def = default )
		{
			var memStream = new MemoryStream();
			var binForm = new BinaryFormatter();

			memStream.Write( arrBytes, 0, arrBytes.Length );
			memStream.Seek( 0, SeekOrigin.Begin );

			if ( useStringAssembly )
				binForm.Binder = new FromAllAssembliesDeserializationBinder();

			try
			{
				return (T) binForm.Deserialize( memStream );
			}
			catch ( Exception e )
			{
				Debug.LogWarning( e );
				return def;
			}
		}


		private sealed class FromAllAssembliesDeserializationBinder : SerializationBinder
		{
			public override Type BindToType( string assemblyName, string typeName )
			{
				foreach ( var assembly in AppDomain.CurrentDomain.GetAssemblies() )
				{
					var type = Type.GetType( $"{typeName}, {assembly.FullName}" );
					if ( type != null )
						return type;
				}

				// For each assemblyName/typeName that you want to deserialize to
				// a different type, set typeToDeserialize to the desired type
				var exeAssembly = Assembly.GetExecutingAssembly().FullName;

				// The following line of code returns the type
				var typeToDeserialize = Type.GetType( $"{typeName}, {exeAssembly}" );

				return typeToDeserialize;
			}
		}
	}
}

