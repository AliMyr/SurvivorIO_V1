using System.Collections.Generic;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCharacter : Character
{
    [SerializeField] private CinemachineCamera cinemachineCamera;

    private Vector2 moveInput;
    private bool isSprinting;

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

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    public void OnSprint(InputValue value)
    {
        isSprinting = value.Get<float>() > 0.5f;
    }

    public void OnAttack(InputValue value)
    {
        if (CharacterTarget != null)
        {
            AttackComponent.MakeDamage(CharacterTarget);
        }
    }

    protected override void Update()
    {
        if (!GameManager.Instance.IsGameActive) return;
        if (HealthComponent.CurrentHealth <= 0) return;

        Vector3 cameraForward = GetCameraForward();
        Vector3 cameraRight = GetCameraRight();
        Vector3 moveDirection = (cameraForward * moveInput.y + cameraRight * moveInput.x).normalized;

        MovementComponent.SetSprintSpeed(isSprinting);

        if (moveDirection != Vector3.zero)
        {
            MovementComponent.Move(moveDirection);
        }

        if (CharacterTarget != null)
        {
            Vector3 rotationDirection = CharacterTarget.transform.position - transform.position;
            rotationDirection.y = 0;
            rotationDirection.Normalize();
            MovementComponent.Rotation(rotationDirection);
        }
        else
        {
            MovementComponent.Rotation(moveDirection);
        }
    }

    private Vector3 GetCameraForward()
    {
        if (cinemachineCamera == null) return transform.forward;

        Vector3 forward = cinemachineCamera.transform.forward;
        forward.y = 0;
        return forward.normalized;
    }

    private Vector3 GetCameraRight()
    {
        if (cinemachineCamera == null) return transform.right;

        Vector3 right = cinemachineCamera.transform.right;
        right.y = 0;
        return right.normalized;
    }
}