using UnityEngine;
using System.Collections.Generic; // C?n import này

// 1. Thay ??i k? th?a sang BaseWeaponHandler
public class EnemyWeaponHandler : WeaponHandlerAbstract
{
    [Header("Enemy Config")]
    // [SerializeField] private GunSO enemyGunSO; // Xóa ho?c b? comment bi?n này
    // [SerializeField] private int weaponLevel = 1; // Xóa ho?c b? comment bi?n này

    // DANH SÁCH CÁC SÚNG CÓ TH? R?I (Setup trong Inspector)
    [SerializeField] protected List<GunSO> availableGuns;
    [SerializeField] protected GunSO selectedGun;
    [SerializeField] private int weaponLevel;

    [Header("Map Reference")]
    // **GI? ??NH** b?n có m?t cách ?? l?y Map Level
    [SerializeField]
    private int mapLevel; // Giá tr? m?c ??nh ho?c ???c gán t? MapManager/GameManager

    // 2. LoadComponents và LoadGunShooting ?ã có ? l?p cha
    // (Xóa chúng kh?i file này)

    // 3. Start() gi? làm 2 vi?c: ch?n ng?u nhiên súng và l?y level, sau ?ó g?i SetupWeapon
    protected override void Start()
    {
        // 1. L?y Map Level th?c t? (N?u b?n có GameManager/MapManager)
        // Ví d?: mapLevel = GameManager.Instance.CurrentMapLevel;
        // Hi?n t?i, ta dùng giá tr? gán trong Inspector cho demo.
        mapLevel = DataSaver.Instance.PlayerLevel; // L?y level t? DataSaver

        // 2. Ch?n ng?u nhiên GunSO
        selectedGun = this.GetRandomGun();

        if (selectedGun == null)
        {
            Debug.LogError("Không có GunSO nào trong danh sách 'availableGuns'!", this.gameObject);
            return;
        }
        // 3. Tính toán Weapon Level
        // Súng c?a Enemy s? có level b?ng level map (ho?c +/- m?t giá tr? nh?)
        // ??m b?o level t?i thi?u là 1
        weaponLevel = Mathf.Max(1, this.mapLevel);

        // 4. G?i hàm t? l?p cha
        SetupWeapon(selectedGun, weaponLevel);
    }

    /// <summary>
    /// Ch?n ng?u nhiên m?t GunSO t? danh sách availableGuns.
    /// </summary>
    /// <returns>GunSO ???c ch?n ng?u nhiên, ho?c null n?u danh sách r?ng.</returns>
    private GunSO GetRandomGun()
    {
        if (availableGuns == null || mapLevel == 0)
        {
            return null;
        }

        int randomIndex = Random.Range(0, mapLevel);
        return availableGuns[randomIndex];
    }
}