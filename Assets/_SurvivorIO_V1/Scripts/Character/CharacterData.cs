using UnityEngine;

public class CharacterData : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;
    [SerializeField] private Transform characterTransform;
    [SerializeField] private float defaultSpeed;
    //[SerializeField] private float damage;
    //[SerializeField] private float attackRange;

    public CharacterController CharacterController => characterController;
    public Transform CharacterTransform => characterTransform;
    public float DefaultSpeed => defaultSpeed;
    //public float Damage => damage;
    //public float AttackRange => attackRange;
}