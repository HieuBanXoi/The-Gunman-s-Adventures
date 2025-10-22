using System;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PlayerMovement : CoreMonoBehaviour
{
    [Header("PlayerMovement")]
    [SerializeField] protected float moveSpeed = 5f;

    [SerializeField] protected float originalMoveSpeed = 5f;

    [SerializeField] protected Vector3 moveInput;
    [SerializeField] protected PlayerCtrl playerCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadPlayerCtrl();
    }
    protected virtual void LoadPlayerCtrl()
    {
        if (this.playerCtrl != null) return;
        this.playerCtrl = transform.parent.GetComponent<PlayerCtrl>();
        Debug.Log(transform.name + ": LoadPlayerCtrl", gameObject);
    }
    private void Update()
    {
        //
    }
    private void FixedUpdate()
    {
        this.Moving();
    }

    protected virtual void Moving()
    {
        moveInput.x = InputManager.Instance.OnHorizontal;
        moveInput.y = InputManager.Instance.OnVertical;
        moveInput = moveInput.normalized;
        transform.parent.position += moveInput * (moveSpeed * Time.fixedDeltaTime);
    }
    public virtual void BoostSpeed(float newMoveSpeed)
    {
        this.moveSpeed *= newMoveSpeed;
    }
    public virtual void ResetSpeed()
    {
        this.moveSpeed = this.originalMoveSpeed;
    }
}
    
