using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class DamageReceiver : CoreMonoBehaviour
{
    [SerializeField] protected SphereCollider sphereCollider;
    [SerializeField] protected int healthPoint = 100;
    [SerializeField] protected int maxHealthPoint = 100;
    [SerializeField] protected bool isDead = false;

    protected override void OnEnable()
    {
        Reborn();
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCollider();
    }
    protected virtual void LoadCollider()
    {
        if (this.sphereCollider != null) return;
        this.sphereCollider = GetComponent<SphereCollider>();
        this.sphereCollider.isTrigger = true;
        this.sphereCollider.radius = 0.5f;
        Debug.Log(transform.name + ": LoadCollider", gameObject);
    }
    protected virtual void Reborn()
    {
        this.healthPoint = this.maxHealthPoint;
        this.isDead = false;
    }
    public virtual void Add(int value)
    {
        if (this.isDead) return;
        this.healthPoint += value;
        if (this.healthPoint > this.maxHealthPoint) this.healthPoint = this.maxHealthPoint;
    }
    public virtual void Detuct(int value)
    {
        if (this.isDead) return;
        this.healthPoint -= value;
        if (this.healthPoint <= 0) this.healthPoint=0;
        CheckIsDead();
    }
    protected virtual bool IsDead()
    {
        return this.healthPoint <= 0;
    }
    protected virtual void CheckIsDead()
    {
        if (!IsDead()) return;
        this.isDead = true;
        OnDead();
    }
    protected virtual void OnDead()
    {
        Debug.Log(transform.name + " is dead", gameObject);
    }
}
