using UnityEngine;

public class EnemyHPBar : HPBarAbstract, IDamageReceiveObserver
{
    [Header("Enemy HP Bar")]
    [SerializeField] protected EnemyCtrl enemyCtrl;
    [SerializeField] protected FollowTarget followTarget;
    [SerializeField] protected Spawner spawner;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadFollowTarget();
        this.LoadSpawner();
    }
    protected override void RegisterAppearEvent()
    {
        this.enemyCtrl.DamageReceiver.ObserverAdd(this);
    }
    protected virtual void LoadSpawner()
    {
        if (this.spawner != null) return;
        this.spawner = transform.parent.parent.GetComponent<Spawner>();
        Debug.LogWarning(transform.name + ": LoadSpawner", gameObject);
    }
    protected virtual void LoadFollowTarget()
    {
        if (this.sliderHP != null) return;
        this.sliderHP = transform.GetComponentInChildren<SliderHP>();
        Debug.LogWarning(transform.name + ": LoadFollowTarget", gameObject);
    }
    
    protected override void HPShowing()
    {
        if (this.enemyCtrl == null) return;
        bool isDead = this.enemyCtrl.DamageReceiver.IsDead();
        if (isDead)
        {
            this.spawner.Despawn(transform);
            return;
        }
        float hp = this.enemyCtrl.DamageReceiver.HealthPoint;
        float maxHp = this.enemyCtrl.DamageReceiver.MaxHealthPoint;
        this.sliderHP.SetCurrentHP(hp);
        this.sliderHP.SetMaxHP(maxHp);
    }
    public virtual void SetObjectCtrl(EnemyCtrl enemyCtrl)
    {
        this.enemyCtrl = enemyCtrl;
    }
    public virtual void SetFollowTarget(Transform target)
    {
        this.followTarget.SetTarget(target);
    }
}
