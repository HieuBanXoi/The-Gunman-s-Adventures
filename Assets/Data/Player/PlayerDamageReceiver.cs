using UnityEngine;

public class PlayerDamageReceiver : DamageReceiver
{
    [Header("PlayerDamageReceiver")]
    [SerializeField] protected PlayerCtrl playerCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCtrl();
    }
    protected virtual void LoadCtrl()
    {
        if (this.playerCtrl != null) return;
        this.playerCtrl = transform.parent.GetComponent<PlayerCtrl>();
        Debug.Log(transform.name + ": LoadPlayerCtrl", gameObject);
    }
    protected override void OnDead()
    {
        //OnDeadFX();
        //OnDeadDrop();
        //shootableObjectCtrl.Despawn.DespawnObject();
    }
    
    protected virtual void OnDeadFX()
    {
        string fxName = this.GetOnDeadFXName();
        Transform fxOnDead = FXSpawner.Instance.Spawn(fxName, transform.position, transform.rotation);
        fxOnDead.gameObject.SetActive(true);
    }
    protected virtual string GetOnDeadFXName()
    {
        return FXSpawner.smoke1;
    }
    //protected override void Reborn()
    //{
    //    this.maxHealthPoint = this.shootableObjectCtrl.ShootableObject.maxHealthPoint;
    //    base.Reborn();
    //}
}
