using System.Collections;
using UnityEngine;

public class PlayerDash : CoreMonoBehaviour
{
    [Header("Dash Settings")]
    [SerializeField] protected float dashSpeedMultiplier = 4f; // T?ng t?c g?p 4 l?n
    [SerializeField] protected float dashDuration = 0.5f;      // Th?i gian l??t
    [SerializeField] protected float dashCooldown = 2.0f;      // Th?i gian h?i chiêu

    [Header("References")]
    [SerializeField] protected PlayerCtrl playerCtrl;
    public PlayerCtrl PlayerCtrl { get => playerCtrl; }
    [SerializeField] protected PlayerMovement playerMovement;

    private bool canDash = true;
    //private bool isDashing = false;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayerCtrl();
    }
    protected virtual void LoadPlayerCtrl()
    {
        if (this.playerCtrl != null) return;
        this.playerCtrl = transform.parent.GetComponent<PlayerCtrl>();
        Debug.LogWarning(transform.name + ": LoadPlayerCtrl", gameObject);
    }
    protected override void Start()
    {
        playerMovement = playerCtrl.PlayerMovement;
    }
    private void FixedUpdate()
    {
        this.DashChecking();
    }

    protected virtual void DashChecking()
    {
        // B?n có th? thay Input.GetKeyDown b?ng InputManager.Instance.IsDash n?u có
        if (InputManager.Instance.OnSpaceDown && canDash)
        {
            StartCoroutine(DashRoutine());
        }
    }

    private IEnumerator DashRoutine()
    {
        // 1. Chu?n b? Dash
        canDash = false;
        //isDashing = true;

        // 2. T?ng t?c ??
        // L?u ý: Hàm BoostSpeed c?a b?n dùng phép nhân (*=), nên truy?n vào s? l?n g?p (ví d? 4)
        if (playerMovement != null)
        {
            playerMovement.BoostSpeed(dashSpeedMultiplier);
        }

        // 3. Ch? h?t th?i gian Dash (0.5s)
        yield return new WaitForSeconds(dashDuration);

        // 4. Reset t?c ?? v? ban ??u
        if (playerMovement != null)
        {
            playerMovement.ResetSpeed();
        }
        //isDashing = false;

        // 5. Ch? h?i chiêu (2s)
        yield return new WaitForSeconds(dashCooldown);

        // 6. Hoàn t?t
        canDash = true;
        Debug.Log("Dash Ready");
    }
}