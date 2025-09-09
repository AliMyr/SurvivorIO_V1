using UnityEngine;

public abstract class Character : MonoBehaviour
{
    public IHealthComponent HealthComponent { get; protected set; }

    public virtual void Initialize()
    {
        Debug.Log("Character initialized");
    }

    private void Start()
    {
        Initialize();
    }
}