using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIItemInventory : CoreMonoBehaviour
{
    [Header("UI Item Inventory")]
    [SerializeField] protected TextMeshProUGUI itemName;
    public TextMeshProUGUI ItemName => itemName;
    [SerializeField] protected TextMeshProUGUI itemNumber;
    public TextMeshProUGUI ItemNumer => itemNumber;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadItemName();
        this.LoadItemNumer();
    }
    protected virtual void LoadItemName()
    {
        if (this.itemName != null) return;
        this.itemName = transform.Find("ItemName").GetComponent<TextMeshProUGUI>();
        Debug.Log(transform.name + ": LoadItemName", gameObject);
    }
    protected virtual void LoadItemNumer()
    {
        if (this.itemNumber != null) return;
        this.itemNumber = transform.Find("ItemNumber").GetComponent<TextMeshProUGUI>();
        Debug.Log(transform.name + ": LoadItemNumer", gameObject);
    }
    public virtual void ShowItem(ItemInventory item)
    {
        this.itemName.text = item.itemProfile.itemName;
        this.itemNumber.text = item.itemCount.ToString();
    }
}
