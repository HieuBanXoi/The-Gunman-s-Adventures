using UnityEngine;

public class ShootableObjectDamageReceiver : DamageReceiver
{
    [Header("Shootable Object")]
    [SerializeField] protected ShootableObjectCtrl shootableObjectCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCtrl();
    }
    protected virtual void LoadCtrl()
    {
        if (this.shootableObjectCtrl != null) return;
        this.shootableObjectCtrl = transform.parent.GetComponent<ShootableObjectCtrl>();
        Debug.Log(transform.name + ": LoadShootableObjectCtrl", gameObject);
    }
    protected override void OnDead()
    {
        OnDeadFX();
        OnDeadDrop();
        shootableObjectCtrl.Despawn.DespawnObject();
    }
    protected virtual void OnDeadDrop()
    {
        ItemDropSpawner.Instance.Drop(this.shootableObjectCtrl.ShootableObject.dropList, transform.position, transform.rotation);
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
    protected override void Reborn()
    {
        this.maxHealthPoint = this.shootableObjectCtrl.ShootableObject.maxHealthPoint;
        base.Reborn();
    }
}
