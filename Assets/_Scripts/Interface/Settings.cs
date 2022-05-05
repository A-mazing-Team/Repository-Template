using System.Collections;
using System.Collections.Generic;
using AmazingTeam.Saves;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    #region Settings
    [SerializeField] private Image _vibroButton;
    [SerializeField] private Image _soundsButton;
    [SerializeField] private Sprite[] _vibroIcons;
    [SerializeField] private Sprite[] _soundIcons;
    [SerializeField] private GameObject _content;
    #endregion
    #region Variables

    #endregion
    #region UnityMethods
    private void Start()
    {
        _soundsButton.overrideSprite = _soundIcons[Saves.Sounds ? 1 : 0];

        AudioSource[] audios = GameObject.FindObjectsOfType<AudioSource>(true);
        for (int i = 0; i < audios.Length; i++)
            audios[i].mute = !Saves.Sounds;

        _vibroButton.overrideSprite = _vibroIcons[Saves.Vibro ? 1 : 0];

        Taptic.tapticOn = Saves.Vibro;
    }
    #endregion
    #region SettingsLogic
    public void Switch()
    {
        _content.SetActive(!_content.activeSelf);
    }

    public void SwitchSound()
    {
        Saves.Sounds = !Saves.Sounds;
        _soundsButton.overrideSprite = _soundIcons[Saves.Sounds ? 1 : 0];

        AudioSource[] audios = FindObjectsOfType<AudioSource>(true);
        for (int i = 0; i < audios.Length; i++)
            audios[i].mute = !Saves.Sounds;
    }

    public void SwitchVibro()
    {
        Saves.Vibro = !Saves.Vibro;
        _vibroButton.overrideSprite = _vibroIcons[Saves.Vibro ? 1 : 0];

        Taptic.tapticOn = Saves.Vibro;
    }
    #endregion
}