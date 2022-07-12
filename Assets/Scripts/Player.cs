using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float _maxHealth = 100;
    private float _health;

    public event Action HealthChanged;
    
    public float MaxHealth => _maxHealth;
    public float Health => _health;
    
    private void Awake()
    {
        _health = _maxHealth;
        HealthChanged?.Invoke();
    }

    public void TakeDamage(float damage)
    {
        ChangeHealth(-damage);
    }

    public void Heal(float healPoints)
    {
        ChangeHealth(healPoints);
    }

    private void ChangeHealth(float points)
    {
        _health += points;
        _health = Mathf.Clamp(_health, 0, _maxHealth);
        HealthChanged?.Invoke();
    }
}
