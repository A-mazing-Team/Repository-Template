namespace _Scripts.SaveSystem2
{
	using UnityEngine;

	[CreateAssetMenu( fileName = "SaveSettings", menuName = "Configs/SaveSettings" )]
	public class SaveSettings : ScriptableObject
	{
		public bool DeleteSaveWhenStartAtEditor;
		public bool DeletePrefsWhenStartAtEditor;

		[Space]
		public bool SoundOnDefault;
		public bool VibrateOnDefault;
	}
}

