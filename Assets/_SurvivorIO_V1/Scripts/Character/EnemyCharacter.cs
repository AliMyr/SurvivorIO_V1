using UnityEngine;

public class EnemyCharacter : Character
{
    [SerializeField] private AiState aiState;

    private float timeBetweenAttackCounter;

    public override Character CharacterTarget => GameManager.Instance.CharacterFactory.Player;

    public override void Initialize()
    {
        base.Initialize();

        HealthComponent = new HealthComponent();
        HealthComponent.Initialize(this);

        timeBetweenAttackCounter = 0f;
    }

    protected override void Update()
    {
        if (!GameManager.Instance.IsGameActive) return;
        if (HealthComponent.CurrentHealth <= 0) return;
        if (CharacterTarget == null) return;

        switch (aiState)
        {
            case AiState.Idle:
                break;

            case AiState.MoveToTarget:
                ProcessMoveToTarget();
                break;
        }
    }

    private void ProcessMoveToTarget()
    {
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
    }
}