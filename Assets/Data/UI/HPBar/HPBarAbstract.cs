using UnityEngine;

public abstract class HPBarAbstract : CoreMonoBehaviour, IDamageReceiveObserver
{
    [Header("HP Bar")]
    [SerializeField] protected SliderHP sliderHP;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSliderHp();
    }
    protected override void OnEnable()
    {
        base.OnEnable();
        this.RegisterAppearEvent();
        this.HPShowing();
    }
    protected virtual void LoadSliderHp()
    {
        if (this.sliderHP != null) return;
        this.sliderHP = transform.GetComponent<SliderHP>();
        Debug.LogWarning(transform.name + ": LoadFollowTarget", gameObject);
    }
    public void OnHPChanged()
    {
        this.HPShowing();
    }
    public void IsDead()
    {
        //None
    }
    protected abstract void RegisterAppearEvent();
    protected abstract void HPShowing(); 
}
