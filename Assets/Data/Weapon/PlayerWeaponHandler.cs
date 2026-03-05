using UnityEngine;
using System.Collections.Generic;
using System.Linq;

// 1. Thay ??i k? th?a sang BaseWeaponHandler
public class PlayerWeaponHandler : WeaponHandlerAbstract
{
    [Header("Player Config")]
    [SerializeField] private List<GunSO> allGunSOs;

    // 2. LoadComponents và LoadGunShooting ?ã có ? l?p cha
    // (Xóa chúng kh?i file này)

    // 3. Start() gi? ch? t?p trung vào vi?c l?y data
    protected override void Start()
    {
        if (DataSaver.Instance == null || DataSaver.Instance.playerData == null)
        {
            Debug.LogError("Không tìm th?y DataSaver ho?c PlayerData!", this.gameObject);
            return;
        }

        // 1. L?y inventory t? DataSaver
        List<WeaponData> inventory = DataSaver.Instance.playerData.inventory;

        // 2. Tìm súng ?ang ???c trang b?
        WeaponData equippedWeaponData = inventory.Find(w => w.is_equipped == true);

        // 3. N?u không tìm th?y súng nào (l?i), m?c ??nh dùng Pistol
        if (equippedWeaponData == null)
        {
            Debug.LogWarning("Không tìm th?y súng trang b?! M?c ??nh dùng Pistol.");
            equippedWeaponData = inventory.Find(w => w.item_id == "Pistol");
        }

        if (equippedWeaponData == null)
        {
            Debug.LogError("Không th? tìm th?y súng 'Pistol' m?c ??nh!", this.gameObject);
            return;
        }

        // 4. Tìm GunSO t??ng ?ng
        GunSO gunSO = allGunSOs.Find(so => so.gunType.ToString() == equippedWeaponData.item_id);

        if (gunSO == null)
        {
            Debug.LogError("Không tìm th?y GunSO cho item_id: " + equippedWeaponData.item_id, this.gameObject);
            return;
        }

        // 5. G?i hàm t? l?p cha v?i data c?a Player
        SetupWeapon(gunSO, equippedWeaponData.level);
    }

    // 4. Xóa hàm LoadEquippedWeapon()
    // (Toàn b? logic ?ã ???c chuy?n vào hàm SetupWeapon c?a l?p cha)
}