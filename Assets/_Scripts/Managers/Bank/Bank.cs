using UnityEngine;
using System;

public enum CurrencyType { Hard, Soft}

public class Bank : MonoBehaviour
{
    public event Action OnCurrencyAmountChangedEvent;

    [SerializeField] private Currency _hard;
    [SerializeField] private Currency _soft;

    public Currency Hard => _hard;
    public Currency Soft => _soft;

    private void Awake()
    {
        Hard.OnAmountChangedEvent += OnCurrencyAmountChanged;
        Soft.OnAmountChangedEvent += OnCurrencyAmountChanged;
    }

    private void OnCurrencyAmountChanged()
    {
        OnCurrencyAmountChangedEvent?.Invoke();
    }
}

[Serializable]
public class Currency
{
    public event Action OnAmountChangedEvent;
    [SerializeField] private int _defaultAmount;
    [Header("Saving")]
    [SerializeField] private string _saveKey;
    [Header("Testing")]
    [SerializeField] private bool _isTesting;
    [SerializeField] private int _testAmount = 99999;

    private int _amount = Consts.NOT_ASSIGNED_VALUE;
    public int Amount
    {
        get
        {
            if (_isTesting) return _amount;
            return PlayerPrefs.GetInt(_saveKey, _defaultAmount);
        }
        set
        {
            if (value < 0) value = 0;
            if (value == _amount) return;
            _amount = value;
            if (_isTesting == false) PlayerPrefs.SetInt(_saveKey, value);

            OnAmountChangedEvent?.Invoke();
        }
    }
}
