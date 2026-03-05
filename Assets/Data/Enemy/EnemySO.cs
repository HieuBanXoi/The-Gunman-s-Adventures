using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "SO/EnemySO")]
public class EnemySO : ScriptableObject
{
    public string objectName = "Enemy";
    public int maxHealthPoint = 100;
    public List<ItemDropRate> dropList;
}
