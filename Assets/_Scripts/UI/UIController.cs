using Sirenix.OdinInspector;
using UnityEngine;

public class UIController : MonoBehaviour
{
    #region Variables
    [SerializeField] private UIPanel[] panels;

    public enum Windows { Game, Victory, Lose }
    [Space(20)]
    [SerializeField] private Windows currentWindow;
    #endregion

    [Button]
    public void ChangeWindow()
    {
        foreach (UIPanel panel in panels)
        {
            panel.Hide(0);
        }

        panels[(int)currentWindow].Show(0);
    }
}
