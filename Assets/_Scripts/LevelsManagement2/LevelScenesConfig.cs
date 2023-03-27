namespace _Scripts.LevelsManagement2
{
	using System.Collections.Generic;
	using UnityEngine;

	[CreateAssetMenu( fileName = "Scenes", menuName = "Configs/Scenes")]
	public class LevelScenesConfig : ScriptableObject
	{
		public SceneField StartScene;
		
		[Space] 
		//[ListDrawerSettings(ShowPaging = false)] // odin attribute
		public List<SceneField> Levels;

		[Space]
		public bool UseOverride;
		public SceneField OverrideLevel;
	}
}

