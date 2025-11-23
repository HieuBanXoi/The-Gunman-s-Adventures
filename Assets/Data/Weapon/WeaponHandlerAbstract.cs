using UnityEngine;
using System.Collections.Generic;

public class WeaponHandlerAbstract : CoreMonoBehaviour
{
    
    [Header("Base Weapon Setup")]
    // Kéo vào trong Inspector c?a Player và Enemy
    [SerializeField] protected Transform weaponHoldPoint;

    // T? ??ng tìm ? l?p con
    [SerializeField] protected GunShooting gunShooting;

    [Header("Calculated Stats")]
    // Các script khác có th? ??c ch? s? này
    public int CurrentDamage { get; protected set; }
    // public float CurrentFireTime { get; protected set; } // B?n không dùng bi?n này, b?n gán th?ng vào gunShooting

    // === 1. LOGIC CHUNG (GI?NG H?T NHAU) ===

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadGunShooting();
    }

    protected virtual void LoadGunShooting()
    {
        if (this.gunShooting != null) return;
        this.gunShooting = GetComponentInChildren<GunShooting>();
        Debug.Log(transform.name + ": LoadGunShooting", gameObject);
    }

    // === 2. HÀM X? LÝ LOGIC CHUNG ===
    // C? Player và Enemy ??u làm vi?c này, ch? khác nhau v? ??u vào

    /// <summary>
    /// T?i model súng và tính toán ch? s?
    /// </summary>
    /// <param name="gunSO">ScriptableObject c?a súng</param>
    /// <param name="level">Level c?a súng</param>
    protected virtual void SetupWeapon(GunSO gunSO, int level)
    {
        if (gunSO == null)
        {
            Debug.LogError("GunSO b? null, không th? setup v? khí!", this.gameObject);
            return;
        }

        if (weaponHoldPoint == null)
        {
            Debug.LogError("Ch?a gán WeaponHoldPoint!", this.gameObject);
            return;
        }

        

        // T?i model súng m?i
        if (gunSO.gunPrefab != null)
        {
            Instantiate(gunSO.gunPrefab, weaponHoldPoint);
        }
        else
        {
            Debug.LogWarning("GunSO này không có 'gunPrefab' ?? t?o!", this.gameObject);
        }

        // T?i ch? s? (dùng công th?c chung)
        this.CurrentDamage = gunSO.damage + (level - 1) * 5;

        float currentFireTime = gunSO.fireSpeed - (level - 1) * 0.1f;
        currentFireTime = Mathf.Max(currentFireTime, 0.1f);

        // Gán ch? s? vào script b?n
        if (this.gunShooting != null)
        {
            this.gunShooting.shootDelay = currentFireTime;
        }
        else
        {
            Debug.LogError("Không tìm th?y GunShooting!", this.gameObject);
        }

        Debug.Log($"[{transform.name}] ?ã trang b?: {gunSO.objectName} | Level: {level} | Dmg: {this.CurrentDamage} | Rate: {currentFireTime}s");
    }
}
