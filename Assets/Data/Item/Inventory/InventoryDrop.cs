using System;
using UnityEngine;

public class InventoryDrop : InventoryAbstract
{
    protected override void Start()
    {
        base.Start();
        Invoke(nameof(this.Test), 5);
    }

    protected virtual void Test()
    {
        Vector3 dropPos = transform.position;
        dropPos.x += 1;
        this.DropItemIndex(0,dropPos,transform.rotation); 
    }

    protected virtual void DropItemIndex(int itemIndex, Vector3 dropPos,Quaternion rotation)
    {
        ItemInventory itemInventory = this.inventory.Items[itemIndex];

        ItemDropSpawner.Instance.Drop(itemInventory, dropPos, rotation);
        inventory.Items.Remove(itemInventory);
    }
}
