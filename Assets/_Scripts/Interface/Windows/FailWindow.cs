using System.Collections;
using System.Collections.Generic;
using AmazingTeam.Analytics;
using AmazingTeam.Saves;
using UnityEngine;

public class FailWindow : WindowCore
{
    #region Variables
    public bool Opened { get; private set; }
    #endregion

    #region Methods
    public override void Show()
    {
        Opened = true;

        Interface.Instance.GameStatus = Interface.StatusOfGame.End;
        Analytics.OnLevelFail?.Invoke(Saves.Level);
        Taptic.Failure();

        base.Show();
    }

    public override void Hide()
    {
        base.Hide();

        Opened = false;
    }

    public void Restart()
    {
        Map.Instance.LoadLevel();

        Taptic.Light();

        Hide();
    }
    #endregion
}