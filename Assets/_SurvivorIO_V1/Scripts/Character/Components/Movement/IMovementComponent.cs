using UnityEngine;

public interface IMovementComponent
{
    public float Speed { get; set; }
    public Vector3 Position { get; }

    public void Initialize(CharacterData characterData);
    public void Move(Vector3 direction);
    public void Rotation(Vector3 direction);
}