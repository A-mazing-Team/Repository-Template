using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interface : Singleton<Interface>
{
    #region Variables
    [Header("Windows Settings")]
    [SerializeField] private WindowsPreset _windows;
    public WindowsPreset Windows => _windows;

    public StatusOfGame GameStatus { get; set; }
    #endregion

    #region UnityMethods
    public override void Awake()
    {
        base.Awake();

        Application.targetFrameRate = 60;
    }
    #endregion

    #region Structs
    [System.Serializable]
    public struct WindowsPreset
    {
        public CompleteWindow Complete;
        public FailWindow Fail;
        public MenuWindow Menu;
    }
    #endregion

    #region Enums
    public enum StatusOfGame
    {
        Menu,
        Game,
        End
    }
    #endregion
}
