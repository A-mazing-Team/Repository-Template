using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AmazingTeam.Saves;

public class Map : Singleton<Map>
{
    #region Variables
    public Level CurrentLevel { get; private set; }
    #endregion

    #region UnityMethods
    public override void Awake()
    {
        base.Awake();

        LoadLevel();
    }
    #endregion

    #region Generator
    public void LoadLevel()
    {
        CurrentLevel = GetComponentInChildren<Level>();

        return;

        if (CurrentLevel)
            Destroy(CurrentLevel.gameObject);

        CurrentLevel = Instantiate(Resources.Load<GameObject>($"Levels/Level_{Saves.Location}"), transform).GetComponent<Level>();
        CurrentLevel.transform.localPosition = Vector3.zero;
        CurrentLevel.transform.localEulerAngles = Vector3.zero;
    }
    #endregion
}
