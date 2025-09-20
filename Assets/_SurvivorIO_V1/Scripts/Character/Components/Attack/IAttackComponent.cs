public interface IAttackComponent
{
    public float Damage { get; }
    public float AttackRange { get; }

    public void Initialize(CharacterData characterData);
    public void MakeDamage(Character attackTarget);
}