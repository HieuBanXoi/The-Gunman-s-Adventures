using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class UIInventory : UIInventoryAbstract
{
    [Header("UI Inventory")]
    private static UIInventory instance;
    public static UIInventory Instance => instance;

    protected bool isOpen = false;
    protected override void Awake()
    {
        base.Awake();
        if (UIInventory.instance != null) Debug.LogError("Only 1 UIInventory allow to exist");
        UIInventory.instance = this;
    }
    protected override void Start()
    {
        base.Start();
        this.Close();

        InvokeRepeating(nameof(this.ShowItem), 1f, 1f);
    }
    protected virtual void FixedUpdate()
    {
        //this.ShowItem();
    }
    public virtual void Toggle()
    {
        this.isOpen = !this.isOpen;
        if (this.isOpen) this.Open();
        else this.Close();
    }
    public virtual void Open()
    {
        this.inventoryCtrl.gameObject.SetActive(true);
        this.isOpen = true;
    }
    public virtual void Close()
    {
        this.inventoryCtrl.gameObject.SetActive(false);
        this.isOpen = false;
    }
    protected virtual void ShowItem()
    {
        if (!this.isOpen) return;

        this.ClearItems();
        List<ItemInventory> items = PlayerCtrl.Instance.Inventory.Items;
        UIInvItemSpawner itemSpawner = this.inventoryCtrl.UIInvItemSpawner;
        foreach(ItemInventory item in items)
        {
            itemSpawner.SpawnItem(item);
        }
    }

    protected virtual void ClearItems()
    {
        this.inventoryCtrl.UIInvItemSpawner.ClearAllItems();
    }
}
