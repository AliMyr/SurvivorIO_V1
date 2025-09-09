using UnityEngine;

public class PlayerCharacter : Character
{
    public override void Initialize()
    {
        HealthComponent = new ImmortalHealthComponent();
    }
}