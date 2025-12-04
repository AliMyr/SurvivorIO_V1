using UnityEngine;

public class AttackComponent : IAttackComponent
{
    private CharacterData characterData;

    private const float DEFAULT_DAMAGE = 10f;
    private const float DEFAULT_ATTACK_RANGE = 3.0f;

    public float Damage => DEFAULT_DAMAGE;
    public float AttackRange => DEFAULT_ATTACK_RANGE;

    public void Initialize(CharacterData characterData)
    {
        this.characterData = characterData;
    }

    public void MakeDamage(Character attackTarget)
    {
        if (attackTarget == null) return;

        float distance = Vector3.Distance(
            characterData.CharacterTransform.position,
            attackTarget.transform.position
        );

        if (distance <= AttackRange)
        {
            attackTarget.HealthComponent.TakeDamage((int)Damage);
        }
    }
}