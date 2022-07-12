using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float _maxHealth = 100;
    private float _health;

    public event Action<Player> HealthChanged;
    
    public float MaxHealth => _maxHealth;
    public float Health => _health;
    
    private void Awake()
    {
        _health = _maxHealth;
    }

    public void TakeDamage(Damager damager)
    {
        ChangeHealth(-damager.Damage);
    }

    public void Heal(Healer healer)
    {
        ChangeHealth(healer.HealPoints);
    }

    private void ChangeHealth(float points)
    {
        _health += points;
        ClampHealth();
        HealthChanged?.Invoke(this);
    }

    private void ClampHealth()
    {
        _health = Mathf.Clamp(_health, 0, _maxHealth);
    }
}
