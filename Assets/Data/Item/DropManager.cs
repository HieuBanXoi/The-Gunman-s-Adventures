using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class DropManager : CoreMonoBehaviour
{
    private static DropManager instance;
    public static DropManager Instance { get { return instance; } }

    protected override void Awake()
    {
        base.Awake();
        if (DropManager.instance != null) Debug.LogError("Only 1 DropManager allow to exist");
        DropManager.instance = this;
    }
    public virtual void Drop(List<DropRate> dropList)
    {
        Debug.Log(dropList[0].itemSO.itemName);
    }
}
