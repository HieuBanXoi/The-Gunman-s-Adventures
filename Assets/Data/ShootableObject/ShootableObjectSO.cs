using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShootableObject", menuName = "SO/ShootableObject")]
public class ShootableObjectSO : ScriptableObject
{
    public string objectName = "Shootable Object";
    public ObjectType objecttype;
    public int maxHealthPoint = 100;
    public List<ItemDropRate> dropList;
}
