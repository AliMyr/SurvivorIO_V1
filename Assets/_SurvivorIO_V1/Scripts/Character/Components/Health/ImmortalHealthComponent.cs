using System;
using UnityEngine;

public class ImmortalHealthComponent : IHealthComponent
{
    private const float IMMORTAL_HEALTH = 100f;

    public float CurrentHealth => IMMORTAL_HEALTH;
    public float MaxHealth => IMMORTAL_HEALTH;

    public event Action<Character> OnCharacterDeath;
    public event Action<Character> OnCharacterHealthChange;

    public void Initialize(Character selfCharacter)
    {
    }

    public void TakeDamage(int damage)
    {
        Debug.Log("I am Immortal");
    }
}