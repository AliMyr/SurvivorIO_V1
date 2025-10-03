using UnityEngine;

public class EnemyCharacter : Character
{
    [SerializeField]
    public override Character CharacterTarget => GameManager.Instance.CharacterFactory.Player;
    [SerializeField]
    private AiState aiState;

    private float timeBetweenAttackCounter;

    private CharacterData characterData;

    public override void Initialize()
    {
        base.Initialize();
        HealthComponent = new HealthComponent();
    }

    protected override void Update()
    {
        if (HealthComponent.CurrentHealth <= 0)
            return;

        switch (aiState)
        {
            case AiState.Idle:
                return;

            case AiState.MoveToTarget:
                Vector3 moveDirection = CharacterTarget.transform.position - transform.position;
                moveDirection.Normalize();

                MovementComponent.Move(moveDirection);
                MovementComponent.Rotation(moveDirection);

                /*
                if (Vector3.Distance(CharacterTarget.transform.position, transform.position) > 3 && timeBetweenAttackCounter <= 0)
                {
                    AttackComponent.MakeDamage(CharacterTarget);
                    timeBetweenAttackCounter = characterData.TimeBetweenAttacks;
                }

                if (timeBetweenAttackCounter > 0)
                    timeBetweenAttackCounter -= Time.deltaTime;
                
                */

                AttackComponent.MakeDamage(CharacterTarget);

                return;
        }
    }
}