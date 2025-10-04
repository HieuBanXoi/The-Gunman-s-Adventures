using UnityEngine;

public class DamageReceiver : CoreMonoBehaviour
{
    [SerializeField] protected float healthPoint = 100;
    [SerializeField] protected float maxHealthPoint = 100;

    protected override void Start()
    {
        base.Start();
        Reborn();
    }
    protected virtual void Reborn()
    {
        this.healthPoint = this.maxHealthPoint;
    }
    public virtual void Add(float value)
    {
        this.healthPoint += value;
        if (this.healthPoint > this.maxHealthPoint) this.healthPoint = this.maxHealthPoint;
    }
    public virtual void Take(float value)
    {
        this.healthPoint -= value;
        if (this.healthPoint <= 0) this.healthPoint=0;
    }
    protected virtual bool IsDead()
    {
        return this.healthPoint <= 0;
    }
}
