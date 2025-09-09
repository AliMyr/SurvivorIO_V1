using UnityEngine;

public class HealthComponent : IHealthComponent
{
    private float currentHealth;
    private float maxHealth = 100;

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
        Debug.LogError("I am death");
    }
}