using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Editor_Tools : Editor
{
    #region Toolbar
    [MenuItem("Tools/Saves/Clear")]
    public static void ClearAllSaves()
    {
        PlayerPrefs.DeleteAll();
    }
    #endregion
}
