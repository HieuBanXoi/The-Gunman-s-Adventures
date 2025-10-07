using UnityEngine;

public class EnemyDamageReceiver : DamageReceiver
{
    [Header("EnemyDamageReceiver")]
    [SerializeField] protected EnemyCtrl enemyCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemyCtrl();
    }
    protected virtual void LoadEnemyCtrl()
    {
        if (this.enemyCtrl != null) return;
        this.enemyCtrl = transform.parent.GetComponent<EnemyCtrl>();
        Debug.Log(transform.name + ": LoadEnemyCtrl", gameObject);
    }
    protected override void OnDead()
    {
        OnDeadFX();
        OnDeadDrop();
        Destroy(transform.parent.gameObject);
    }
    protected virtual void OnDeadDrop()
    {
        ItemDropSpawner.Instance.Drop(this.enemyCtrl.EnemySO.dropList, transform.position, transform.rotation);
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
        this.maxHealthPoint = this.enemyCtrl.EnemySO.maxHealthPoint;
        base.Reborn();
    }
}
