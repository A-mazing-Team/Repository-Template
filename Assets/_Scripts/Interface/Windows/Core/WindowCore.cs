using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowCore : MonoBehaviour
{
    #region Methods
    public virtual void Show()
    {
        gameObject.SetActive(true);
    }

    public virtual void Hide()
    {
        gameObject.SetActive(false);
    }
    #endregion
}
