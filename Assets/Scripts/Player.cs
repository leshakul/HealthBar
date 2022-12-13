using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int _currentHealth;

    private int _minHealth = 0;
    private int _maxHealth = 100;

    public event UnityAction<float, int> HealthChanged;

    private void Start()
    {
        _currentHealth = _health;
    }

    public void ApplyDamage(int damage)
    {
        if(_currentHealth > _minHealth)
        {
            _currentHealth -= damage;
            HealthChanged?.Invoke(_currentHealth, _maxHealth);
        }
    }

    public void ApplyHealth(int health)
    {
        if (_currentHealth < _maxHealth)
        {
            _currentHealth += health;
            HealthChanged?.Invoke(_currentHealth, _maxHealth);
        }
    }
}
