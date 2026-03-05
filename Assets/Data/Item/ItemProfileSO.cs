using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemProfileSO", menuName = "SO/ItemProfile")]
public class ItemProfileSO : ScriptableObject
{
    public ItemCode itemCode = ItemCode.NoItem;
    public string itemName = "no-name";

    public static ItemProfileSO FindItemByCode(ItemCode itemCode)
    {
        var items = Resources.LoadAll("Item",typeof(ItemProfileSO));
        foreach (ItemProfileSO item in items)
        {
            if (item.itemCode != itemCode) continue;
            return item;
        }
        return null;
    }
}
public enum ItemCode
{
    NoItem = 0,

    Part = 1,
    Coin = 2,
}
public static class ItemCodeParse
{
    public static ItemCode FromString(string str)
    {
        if (string.IsNullOrEmpty(str)) return ItemCode.NoItem;
        return (ItemCode)System.Enum.Parse(typeof(ItemCode), str);
    }
}

