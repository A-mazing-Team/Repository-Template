using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AmazingTeam.Saves;
using AmazingTeam.Analytics;

public class CompleteWindow : WindowCore
{
    #region Variables
    [Header("Effects Settings")]
    [SerializeField] private ParticleSystem[] _completeEffects;

    public bool Opened { get; private set; }
    #endregion

    #region Methods
    public override void Show()
    {
        Interface.Instance.GameStatus = Interface.StatusOfGame.End;

        Taptic.Success();
        Analytics.OnLevelComplete?.Invoke(Saves.Level);

        for (int i = 0; i < _completeEffects.Length; i++)
            _completeEffects[i].Play();

        Interface.Instance.StartCoroutine(Coroutine_Show());
    }

    public override void Hide()
    {
        Opened = false;

        base.Hide();
    }

    public IEnumerator Coroutine_Show()
    {
        Opened = true;

        yield return new WaitForSeconds(1f);

        base.Show();
    }

    public void Next()
    {
        Saves.Level++;
        Saves.Location++;
        if (Saves.Location >= Resources.LoadAll<GameObject>("Levels").Length)
            Saves.Location = 0;

        Map.Instance.LoadLevel();
        Taptic.Light();

        Hide();
    }
    #endregion
}