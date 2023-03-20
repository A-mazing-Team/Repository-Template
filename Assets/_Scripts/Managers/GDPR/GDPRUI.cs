using UnityEngine;
using Zenject;

public class GDPRUI : UIPanel
{
    [Inject] private GDPR _gdpr;

    public void ShowPrivacyPolicy()
    {
        Application.OpenURL(_gdpr.PrivacyURL);
    }

    public void OnAcceptButon()
    {
        _gdpr.AcceptPrivacy();
    }
}
