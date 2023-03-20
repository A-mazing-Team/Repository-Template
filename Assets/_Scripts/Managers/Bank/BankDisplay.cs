using UnityEngine;
using TMPro;
using Zenject;

public class BankDisplay : UIPanel
{
    [SerializeField] private CurrencyType _currencyType;
    [SerializeField] private TextMeshProUGUI _amountText;
    [SerializeField] private string _thousandPostfix = "K";
    [SerializeField] private string _millionPostfix = "KK";

    [Inject] private Bank _bank;

    protected void Awake()
    {
        switch (_currencyType)
        {
            case CurrencyType.Hard:
                _bank.Hard.OnAmountChangedEvent += Refresh;
                break;
            case CurrencyType.Soft:
                _bank.Hard.OnAmountChangedEvent += Refresh;
                break;
        }
    }

    private void Start()
    {
        Refresh();
    }

    private void Refresh()
    {
        float amount = _currencyType == CurrencyType.Hard ? _bank.Hard.Amount : _bank.Soft.Amount;

        string text = amount.ToString();
        if (amount > 1000) text = (amount / 1000).ToString("0.#") + _thousandPostfix;
        if (amount > 1000000) text = (amount / 1000000).ToString("0.#") + _millionPostfix;

        _amountText.text = text;
    }
}