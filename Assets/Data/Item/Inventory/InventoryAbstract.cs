using UnityEngine;

public abstract class InventoryAbstract : CoreMonoBehaviour
{
    [Header("Inventory Abtract")]
    [SerializeField] protected Inventory inventory;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadInventory();
    }
    protected virtual void LoadInventory()
    {
        if (this.inventory != null) return;
        this.inventory = transform.parent.GetComponent<Inventory>();
        Debug.Assert(this.inventory != null, "Missing Inventory", this);
    }
}
