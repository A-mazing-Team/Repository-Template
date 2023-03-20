using UnityEngine;
using Zenject;
//using NaxHelper;

public class GDPR : MonoBehaviour
{
    [SerializeField] private string _privacyURL = "https://madpixel.dev/privacy.html";
    [SerializeField] private bool _showing = false;

    [Inject] private GDPRUI _UI;

    private const string ACCEPTED_KEY = "GDPRAccepted";
    private const int TRUE_VALUE = 1;
    private const int FALSE_VALUE = 0;

    public bool Accepted
    {
        get => PlayerPrefs.GetInt(ACCEPTED_KEY, FALSE_VALUE) == TRUE_VALUE;
        set => PlayerPrefs.SetInt(ACCEPTED_KEY, value ? TRUE_VALUE : FALSE_VALUE);
    }

    public string PrivacyURL => _privacyURL;

    private void Start()
    {
        if (_showing == false) return;
        if (Accepted) return; 

        _UI.TryShow();
    }

    public void AcceptPrivacy()
    {
        if (Accepted == false)
        {
            //MaxSdk.SetHasUserConsent(true);
        }

        Accepted = true;
        _UI.TryHide();
    }
}
