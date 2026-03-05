using System.Collections.Generic;
using UnityEngine;

public class ItemDropSpawner : Spawner
{
    private static ItemDropSpawner instance;
    public static ItemDropSpawner Instance => instance;

    protected override void Awake()
    {
        base.Awake();
        if (ItemDropSpawner.instance != null) Debug.LogError("Only 1 ItemDropSpawner allow to exist");
        ItemDropSpawner.instance = this;
    }

    public virtual void Drop(List<ItemDropRate> dropList, Vector3 pos, Quaternion rot)
    {
        float offset = 0.7f;
        foreach (ItemDropRate itemDropRate in dropList)
        {
            ItemCode itemCode = itemDropRate.itemSO.itemCode;
            int itemDropNum = Mathf.FloorToInt(Random.Range(itemDropRate.minDrop, itemDropRate.maxDrop+1));
            for (int i = 0; i < itemDropNum; i++)
            {
                Transform itemDrop = this.Spawn(itemCode.ToString(), pos, rot);
                if (itemDrop == null) continue;
                itemDrop.gameObject.SetActive(true);
            }
            pos += new Vector3(offset, 0, 0);
        }
    } 
}
