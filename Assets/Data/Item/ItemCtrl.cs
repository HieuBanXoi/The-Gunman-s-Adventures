using UnityEngine;

public class ItemCtrl : CoreMonoBehaviour
{
    [SerializeField] protected ItemDespawn itemDespawn;
    public ItemDespawn ItemDespawn { get => itemDespawn; }
    [SerializeField] private ItemInventory itemInventory;
    public ItemInventory ItemInventory { get => itemInventory; }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadItemDespawn();
        this.LoadItemInventory();
    }

    protected virtual void LoadItemDespawn()
    {
        if (this.itemDespawn != null) return;
        this.itemDespawn = transform.GetComponentInChildren<ItemDespawn>();
        Debug.Log(transform.name + ": LoadItemDespawn", gameObject);
    }
    public virtual void SetItemInventory(ItemInventory itemInventory)
    {
        this.itemInventory = itemInventory;
    }
    protected virtual void LoadItemInventory()
    {
        if (this.itemInventory.itemProfile != null) return;
        ItemCode itemCode = ItemCodeParse.FromString(transform.name);
        ItemProfileSO itemProfile = ItemProfileSO.FindItemByCode(itemCode);
        this.itemInventory.itemProfile= itemProfile;
        this.itemInventory.itemCount = 1;
        Debug.Log(transform.name + ": LoadItemInventory", gameObject);
    }
}
