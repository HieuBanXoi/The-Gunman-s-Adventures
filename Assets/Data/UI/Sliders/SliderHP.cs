using UnityEngine;

public class SliderHP : BaseSlider
{
    [Header("Slider HP Settings")]
    [SerializeField] protected float maxHP = 100f;
    [SerializeField] protected float currentHP = 70f;
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        this.HPShowing();
    }
    protected virtual void HPShowing()
    {
        float hpPercent = currentHP /maxHP;
        this.slider.value = hpPercent;
    }
    protected override void OnChanged(float newValue)
    {
        Debug.Log("HP Slider changed to: " + newValue);
    }
    public virtual void SetMaxHP(float maxHP)
    {
        this.maxHP = maxHP;
    }
    public virtual void SetCurrentHP(float currentHP)
    {
        this.currentHP = currentHP;
    }
}
