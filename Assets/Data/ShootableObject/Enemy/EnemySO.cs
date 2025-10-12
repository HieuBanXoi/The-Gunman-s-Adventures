using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "SO/Enemy")]
public class EnemySO : ScriptableObject
{
    public string enemyName = "Enemy";
    public int maxHealthPoint = 100;
    public List<DropRate> dropList;
}
