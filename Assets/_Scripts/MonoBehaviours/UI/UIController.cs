using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    #region Variables
    [SerializeField] private UIPanel[] panels;

    public enum Windows { Game, Victory, Lose }
    [SerializeField] private Windows currentWindow;
    #endregion

    [ContextMenu("Change Window")]
    public void ChangeWindow()
    {
        foreach (UIPanel panel in panels)
        {
            panel.Hide(0);
        }

        panels[(int)currentWindow].Show(0);
    }
}
