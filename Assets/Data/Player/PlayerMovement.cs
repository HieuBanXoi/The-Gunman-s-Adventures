using System;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PlayerMovement : CoreMonoBehaviour
{
    [SerializeField] protected float moveSpeed = 5f;

    [SerializeField] protected float originalMoveSpeed = 5f;

    [SerializeField] protected Vector3 moveInput;

    [SerializeField] protected bool isRolling = false;
   
    [SerializeField] protected float rollCooldownTimer = 0f;

    [SerializeField] protected float rollCooldown = 2f;

    [SerializeField] protected float rollDelay = 0.25f;

    [SerializeField] protected float rollTimer = 0f;

    private void Update()
    {
        //IsRolling();
    }
    private void FixedUpdate()
    {
        this.Moving();
        this.Rolling();
    }

    protected virtual void Moving()
    {
        moveInput.x = InputManager.Instance.OnHorizontal;
        moveInput.y = InputManager.Instance.OnVertical;
        moveInput = moveInput.normalized;
        transform.parent.position += moveInput * (moveSpeed * Time.fixedDeltaTime);
    }
    protected virtual void Rolling()
    {
        // giảm cooldown nếu > 0
        if (rollCooldownTimer > 0f)
            rollCooldownTimer -= Time.deltaTime;

        // giảm thời gian roll nếu đang roll
        if (isRolling && rollTimer > 0f)
        {
            rollTimer -= Time.deltaTime;

            if (rollTimer <= 0f)
            {
                // hết roll → reset speed
                isRolling = false;
                moveSpeed = originalMoveSpeed;
            }
        }

        // bấm Space để roll nếu có thể
        if (Input.GetKeyDown(KeyCode.Space) && !isRolling && rollCooldownTimer <= 0f)
        {
            isRolling = true;
            rollTimer = rollDelay;              // set thời gian roll
            rollCooldownTimer = rollCooldown;   // set cooldown
            moveSpeed = originalMoveSpeed * 2f; // tăng tốc
        }
    }

}
    
