using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public abstract class DamageReceiver : CoreMonoBehaviour
{
    [SerializeField] protected CircleCollider2D circleCollider;
    [SerializeField] protected int healthPoint = 100;
    [SerializeField] protected int maxHealthPoint = 100;
    [SerializeField] protected bool isDead = false;
    public int HealthPoint { get => healthPoint; }
    public int MaxHealthPoint { get => maxHealthPoint; }
    [SerializeField] protected List<IDamageReceiveObserver> observers = new List<IDamageReceiveObserver>();
    protected override void OnEnable()
    {
        Reborn();
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCollider();
    }
    protected override void ResetValue()
    {
        base.ResetValue();
        Reborn();
    }
    protected virtual void LoadCollider()
    {
        if (this.circleCollider != null) return;
        this.circleCollider = GetComponent<CircleCollider2D>();
        //this.circleCollider.isTrigger = true;
        this.circleCollider.radius = 0.5f;
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
        this.OnHpChanged();
        CheckIsDead();
    }
    public virtual bool IsDead()
    {
        return this.healthPoint <= 0;
    }
    protected virtual void CheckIsDead()
    {
        if (!IsDead()) return;
        this.isDead = true;
        OnDead();
    }
    public virtual void ObserverAdd(IDamageReceiveObserver observer)
    {
        this.observers.Add(observer);
    }
    protected virtual void OnHpChanged()
    {
        foreach (IDamageReceiveObserver observer in observers)
        {
            observer.OnHPChanged();
        }
    }
    protected abstract void OnDead();
}
