using UnityEngine;

public class AbilityDash : BaseAbility
{
    [Header("Ability Dash")]
    [SerializeField] protected bool isDashing =false;
    [SerializeField] protected bool onSpace =false;
    [SerializeField] protected float boostSpeed=2f;
    [SerializeField] protected float dashSpeed=0.5f;

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        this.Dashing();
    }
    protected virtual void Dashing()
    {
        if(!isReady)return;
        if(!onSpace)return;
        if (isDashing)return;
        Debug.LogWarning("Dashing");
        this.isDashing=true;
        this.Boostsped();
        Invoke(nameof(DashFinish),this.dashSpeed);
        //DashFinish();
    }
    protected virtual void DashFinish()
    {
        Debug.LogWarning("<b>DashFinish</b>");
        this.ResetSpeed();
        this.isDashing = false;
        this.ResetTimer();
    }
    protected virtual void Boostsped()
    {
        this.abilities.PlayerCtrl.PlayerMovement.BoostSpeed(this.boostSpeed);
    }
    protected virtual void ResetSpeed()
    {
        this.abilities.PlayerCtrl.PlayerMovement.ResetSpeed();
    }
}
