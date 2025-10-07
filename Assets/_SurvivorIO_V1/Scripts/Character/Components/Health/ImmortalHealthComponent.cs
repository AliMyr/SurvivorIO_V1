using System;
using UnityEngine;

public class ImmortalHealthComponent : IHealthComponent
{
    public float CurrentHealth => 100;
    public float MaxHealth => 100;

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