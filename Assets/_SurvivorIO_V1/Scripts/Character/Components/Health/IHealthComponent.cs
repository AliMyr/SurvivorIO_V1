using System;
using UnityEngine;

public interface IHealthComponent : ICharacterComponent
{
    public event Action<Character> OnCharacterHealthChange;
    public event Action<Character> OnCharacterDeath;

    public float CurrentHealth { get; }
    public float MaxHealth { get; }

    public void TakeDamage(int damage);
}