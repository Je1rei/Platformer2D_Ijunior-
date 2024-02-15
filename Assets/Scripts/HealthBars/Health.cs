using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _value;
    [SerializeField] private int _maxValue = 100;
    [SerializeField] private int _minValue = 0;

    public event Action<int> Changed;
    public event Action<int> ReachedZero;

    public int MaxValue { get; private set; }
    public int Value => _value;
    public int MinValue => _minValue;

    private void Start()
    {
        MaxValue = _maxValue;
        Changed?.Invoke(_value);
    }

    public void TakeDamage(int damage)
    {
        _value -= damage;
        _value = Mathf.Clamp(_value, _minValue, MaxValue);
        Changed?.Invoke(_value);

        ReachedZero?.Invoke(_value);
    }

    public void Heal(int healValue)
    {
        _value += healValue;
        _value = Mathf.Clamp(_value, _minValue, MaxValue);
        Changed?.Invoke(_value);
    }
}
