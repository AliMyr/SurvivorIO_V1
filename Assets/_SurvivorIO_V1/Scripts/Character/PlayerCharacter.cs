using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : Character
{
    public override Character CharacterTarget
    {
        get
        {
            Character target = null;
            float minDistance = float.MaxValue;
            List<Character> list = GameManager.Instance.CharacterFactory.ActiveCharacters;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].CharacterType == CharacterType.Player) continue;

                float distanceBetween = Vector3.Distance(list[i].transform.position, transform.position);
                if (distanceBetween < minDistance)
                {
                    target = list[i];
                    minDistance = distanceBetween;
                }
            }

            return target;
        }
    }

    public override void Initialize()
    {
        base.Initialize();
        HealthComponent = new HealthComponent();
        HealthComponent.Initialize(this);
    }

    protected override void Update()
    {
        if (HealthComponent.CurrentHealth <= 0 || !GameManager.Instance.IsGameActive) return;

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 moveDirection = new Vector3(horizontalInput, 0, verticalInput).normalized;

        if (CharacterTarget == null)
        {
            MovementComponent.Rotation(moveDirection);
        }
        else
        {
            Vector3 rotationDirection = CharacterTarget.transform.position - transform.position;
            rotationDirection.y = 0;
            rotationDirection.Normalize();

            MovementComponent.Rotation(rotationDirection);

            if (Input.GetButtonDown("Jump"))
                AttackComponent.MakeDamage(CharacterTarget);
        }

        MovementComponent.Move(moveDirection);
    }
}