using UnityEngine;
using System;

public class Live : MonoBehaviour
{
    public event Action OnHealthChangedEvent;
    public event Action OnDeadEvent;
    public event Action OnRevivedEvent;

    #region Variables
    [SerializeField] private float _maxHealth = 100;
    [SerializeField] private bool _debug;
    #endregion

    #region Properties
    public Transform Transform => transform;
    public float MaxHealth => _maxHealth;

    private float _health;
    public float Health
    {
        get => _health;
        set
        {
            value = Mathf.Clamp(value, 0, MaxHealth);
            if (value == _health) return;

            _health = value;
            IsDead = _health == 0;
            OnHealthChangedEvent?.Invoke();
        }
    }

    private bool _isDead;
    public bool IsDead
    {
        get => _isDead;
        private set
        {
            if (value == _isDead) return;

            _isDead = value;
            if (_isDead) OnDeadEvent?.Invoke();
            else OnRevivedEvent?.Invoke();
        }
    }
    #endregion

    private void Start()
    {
        ResetHealth();
    }

    public void GetDamage(float damage)
    {
        Health -= damage;
        if (_debug) Debug.Log($"{gameObject.name} taked dmage ({damage})");
    }

    public void ResetHealth()
    {
        Health = MaxHealth;
    }
}