using UnityEngine;

public class EnemyCharacter : Character
{
    public override Character CharacterTarget => GameManager.Instance.CharacterFactory.Player;

    [SerializeField]
    private AiState aiState;

    private float timeBetweenAttackCounter;

    public override void Initialize()
    {
        base.Initialize();
        HealthComponent = new HealthComponent();
        HealthComponent.Initialize(this);
        timeBetweenAttackCounter = 0f;
    }

    protected override void Update()
    {
        if (HealthComponent.CurrentHealth <= 0 || !GameManager.Instance.IsGameActive) return;
        if (CharacterTarget == null) return;

        switch (aiState)
        {
            case AiState.Idle:
                return;

            case AiState.MoveToTarget:
                Vector3 moveDirection = CharacterTarget.transform.position - transform.position;
                moveDirection.y = 0;
                moveDirection.Normalize();

                MovementComponent.Move(moveDirection);
                MovementComponent.Rotation(moveDirection);

                timeBetweenAttackCounter -= Time.deltaTime;

                float distance = Vector3.Distance(CharacterTarget.transform.position, transform.position);
                if (distance <= AttackComponent.AttackRange && timeBetweenAttackCounter <= 0f)
                {
                    AttackComponent.MakeDamage(CharacterTarget);
                    timeBetweenAttackCounter = CharacterData.TimeBetweenAttacks;
                }

                return;
        }
    }
}
