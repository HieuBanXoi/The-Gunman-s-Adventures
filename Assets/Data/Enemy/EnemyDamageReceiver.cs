using UnityEngine;

public class EnemyDamageReceiver : DamageReceiver
{
    [Header("Shootable Object")]
    [SerializeField] protected EnemyCtrl enemyCtrl;
    [SerializeField] protected bool isShowHpBar = false;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCtrl();
    }
    protected virtual void LoadCtrl()
    {
        if (this.enemyCtrl != null) return;
        this.enemyCtrl = transform.parent.GetComponent<EnemyCtrl>();
        Debug.Log(transform.name + ": LoadEnemyCtrl", gameObject);
    }
    protected override void OnDead()
    {
        enemyCtrl.WeaponHandler.gameObject.SetActive(false);
        enemyCtrl.DissolveEffect.StartDissolve();
        Invoke(nameof(DestroyAfterEffect), enemyCtrl.DissolveEffect.dissolveDuration);
    }
    protected virtual void DestroyAfterEffect()
    {
        OnDeadDrop();
        Destroy(enemyCtrl.transform.parent.gameObject);
    }
    protected virtual void OnDeadDrop()
    {
        ItemDropSpawner.Instance.Drop(this.enemyCtrl.EnemySO.dropList, transform.position, transform.rotation);
    }
    protected override void Reborn()
    {
        this.maxHealthPoint = this.enemyCtrl.EnemySO.maxHealthPoint;
        base.Reborn();
    }
    public override void Detuct(int value)
    {
        base.Detuct(value);
        if (isShowHpBar) return;
        enemyCtrl.AddHPBar2Obj(transform.parent);
        isShowHpBar = true;
    }
}
