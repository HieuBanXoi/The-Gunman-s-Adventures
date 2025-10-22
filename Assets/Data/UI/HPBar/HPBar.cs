using UnityEngine;

public class HPbar : CoreMonoBehaviour
{
    [Header("HP Bar")]
    [SerializeField] protected ShootableObjectCtrl shootableObjectCtrl;
    [SerializeField] protected SliderHP sliderHP;
    [SerializeField] protected FollowTarget followTarget;
    [SerializeField] protected Spawner spawner;
    protected virtual void FixedUpdate()
    {
        this.HPShowing();
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSliderHp();
        this.LoadFollowTarget();
        this.LoadSpawner();
    }
    protected virtual void LoadSliderHp()
    {
        if (this.followTarget != null) return;
        this.followTarget = transform.GetComponent<FollowTarget>();
        Debug.LogWarning(transform.name + ": LoadSliderHP", gameObject);
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

    protected virtual void HPShowing()
    {
        if (this.shootableObjectCtrl == null) return;
        bool isDead = this.shootableObjectCtrl.DamageReceiver.IsDead();
        if (isDead)
        {
            this.spawner.Despawn(transform);
            return;
        }
        float hp = this.shootableObjectCtrl.DamageReceiver.HealthPoint;
        float maxHp = this.shootableObjectCtrl.DamageReceiver.MaxHealthPoint;
        this.sliderHP.SetCurrentHP(hp);
        this.sliderHP.SetMaxHP(maxHp);
    }
    public virtual void SetObjectCtrl(ShootableObjectCtrl shootableObjectCtrl)
    {
        this.shootableObjectCtrl = shootableObjectCtrl;
    }
    public virtual void SetFollowTarget(Transform target)
    {
        this.followTarget.SetTarget(target);
    }
}
