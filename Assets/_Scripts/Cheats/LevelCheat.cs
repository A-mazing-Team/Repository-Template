using UnityEngine;
using Zenject;
using TMPro;
using System.Collections.Generic;

public class LevelCheat : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown _dropDown;

    [Inject] private LevelsManager _levelsManager;


    private void Awake()
    {
        InitOptions();
    }

    private void InitOptions()
    {
        List<string> options = new List<string>(_levelsManager.Levels.Length);

        for(int i = 1; i <= _levelsManager.Levels.Length; i ++)
        {
            options.Add($"Level {i}");
        }

        _dropDown.AddOptions(options);
    }

    public void OnValueChanged(int value)
    {
        _levelsManager.CompletedLevels = value;
        _levelsManager.LevelNumber = value;
        _levelsManager.RestartLevel();
    }
}