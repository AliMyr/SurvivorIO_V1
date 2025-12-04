using System;
using UnityEngine;

public class HealthComponent : IHealthComponent
{
    private Character selfCharacter;
    private float currentHealth;
    private float maxHealth;

    public event Action<Character> OnCharacterDeath;
    public event Action<Character> OnCharacterHealthChange;

    public HealthComponent(float maxHealth = 100f)
    {
        this.maxHealth = maxHealth;
        this.currentHealth = maxHealth;
    }

    public float CurrentHealth
    {
        get => currentHealth;
        private set
        {
            currentHealth = Mathf.Clamp(value, 0, MaxHealth);
            if (currentHealth == 0)
                Death();
        }
    }

    public float MaxHealth => maxHealth;

    public void Initialize(Character selfCharacter)
    {
        this.selfCharacter = selfCharacter;
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        CurrentHealth -= damage;
        OnCharacterHealthChange?.Invoke(selfCharacter);
    }

    private void Death()
    {
        OnCharacterDeath?.Invoke(selfCharacter);
    }
}