using UnityEngine;

public class CharacterData : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;
    [SerializeField] private Transform characterTransform;
    [SerializeField] private float defaultSpeed = 5f;
    [SerializeField] private int scoreCost = 10;
    [SerializeField] private float timeBetweenAttacks = 1f;

    public CharacterController CharacterController => characterController;
    public Transform CharacterTransform => characterTransform;
    public float DefaultSpeed => defaultSpeed;
    public int ScoreCost => scoreCost;
    public float TimeBetweenAttacks => timeBetweenAttacks;
}