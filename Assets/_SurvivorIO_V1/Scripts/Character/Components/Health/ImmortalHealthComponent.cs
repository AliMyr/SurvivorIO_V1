using UnityEngine;

public class ImmortalHealthComponent : IHealthComponent
{
    public float CurrentHealth => 100;
    public float MaxHealth => 100;

    public void TakeDamage(int damage)
    {
        Debug.Log("I am Immortal");
    }
}