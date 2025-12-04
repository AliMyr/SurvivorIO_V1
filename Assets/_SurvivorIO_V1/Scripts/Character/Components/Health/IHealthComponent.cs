using System;

public interface IHealthComponent : ICharacterComponent
{
    event Action<Character> OnCharacterHealthChange;
    event Action<Character> OnCharacterDeath;

    float CurrentHealth { get; }
    float MaxHealth { get; }

    void TakeDamage(int damage);
}