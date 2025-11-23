using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Gun", menuName = "SO/Gun")]
public class GunSO : ScriptableObject
{
    public string objectName = "Gun";
    public GunType gunType;
    public int level = 1;
    public int damage = 10;
    public float fireSpeed = 0.5f;
    public GameObject gunPrefab;
}
public enum GunType
{
    Pistol,
    Rifle,
    Sniper,
    SMG
}
