using UnityEngine;
using UnityEngine.UI;

public abstract class BaseButton : CoreMonoBehaviour
{
    [Header("Base Button)")]
    [SerializeField] protected Button button;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadButton();
    }
    protected override void Start()
    {
        base.Start();
        this.AddOnClickEvent();
    }
    protected virtual void LoadButton()
    {
        if (this.button != null) return;
        this.button = GetComponent<Button>();
        Debug.LogWarning(transform.name + ": LoadButton", gameObject);
    }
    protected virtual void AddOnClickEvent()
    {
        if (this.button == null) return;
        this.button.onClick.AddListener(OnClick);
    }
    protected abstract void OnClick();
}
