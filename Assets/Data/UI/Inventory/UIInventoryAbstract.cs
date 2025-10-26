using UnityEngine;

public abstract class UIInventoryAbstract : CoreMonoBehaviour
{
    [Header("Inventory Abstract")]
    [SerializeField] protected UIInventoryCtrl inventoryCtrl;
    public UIInventoryCtrl InventoryCtrl => inventoryCtrl;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadUIInventoryCtrl();
    }
    protected virtual void LoadUIInventoryCtrl()
    {
        if (this.inventoryCtrl != null) return;
        this.inventoryCtrl = transform.parent.GetComponent<UIInventoryCtrl>();
        Debug.Log(transform.name + ": LoadUIInventoryCtrl", gameObject);
    }
}