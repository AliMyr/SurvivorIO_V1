using UnityEngine;

public interface IHealthComponent
{
    public float CurrentHealth { get; }
    public float MaxHealth { get; }

    public void TakeDamage(int damage);
}