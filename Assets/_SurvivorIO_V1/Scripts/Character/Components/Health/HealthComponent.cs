using System;
using UnityEngine;

public class HealthComponent : IHealthComponent
{
    private Character selfCharacter;

    private float currentHealth = 100;
    private float maxHealth = 100;

    public event Action<Character> OnCharacterDeath;

    public void Initialize(Character selfCharacter)
    {
        this.selfCharacter = selfCharacter;
    }

    public float CurrentHealth
    {
        get
        {
            return currentHealth;
        }

        private set
        {
            currentHealth = Mathf.Clamp(value, 0, MaxHealth);
            if (currentHealth == 0)
                Death();
        }
    }

    public float MaxHealth => maxHealth;

    public void TakeDamage(int damage)
    {
        CurrentHealth -= damage;
    }

    private void Death()
    {
        OnCharacterDeath?.Invoke(selfCharacter);
        Debug.LogError("I am death");
    }
}