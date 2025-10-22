using UnityEngine;

public abstract class BaseAbility : CoreMonoBehaviour
{
    [Header("Base Ability")]
    [SerializeField] protected Abilities abilities;
    public Abilities Abilities { get => abilities; }

    [SerializeField] protected float timer=2f;
    [SerializeField] protected float timeDelay=2f;
    [SerializeField] protected bool isReady=false;

    protected virtual void FixedUpdate()
    {
        Timing();
    }
    protected virtual void Update()
    {
        //
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAbilities();
    }
    protected virtual void LoadAbilities()
    {
        if (this.abilities != null) return;
        this.abilities = transform.parent.GetComponent<Abilities>();
        Debug.LogWarning(transform.name + ": LoadAbilities", gameObject);
    }
    protected virtual void Timing()
    {
        if (isReady) return;
        timer += Time.fixedDeltaTime;
        if (timer < timeDelay) return;
        isReady = true;
    }   
    public virtual void ResetTimer()
    {
        isReady = false;
        timer = 0f;
    }
}
