using UnityEngine;
using UnityEngine.UI;

public abstract class BaseSlider : CoreMonoBehaviour
{
    [Header("Base Slider)")]
    [SerializeField] protected Slider slider;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSlider();
    }
    protected virtual void FixedUpdate()
    {
        //
    }
    protected override void Start()
    {
        base.Start();
        this.AddOnChangedEvent();
    }
    protected virtual void LoadSlider()
    {
        if (this.slider != null) return;
        this.slider = GetComponent<Slider>();
        Debug.LogWarning(transform.name + ": Slider", gameObject);
    }
    protected virtual void AddOnChangedEvent()
    {
        this.slider.onValueChanged.AddListener(OnChanged);
    }
    protected abstract void OnChanged(float newValue);
}
