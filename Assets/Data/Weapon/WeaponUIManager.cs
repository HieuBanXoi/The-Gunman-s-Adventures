using System.Collections.Generic;
using UnityEngine;

public class WeaponUIManager : MonoBehaviour
{
    [Header("Weapon Config")]
    [SerializeField] private List<GunSO> allGunSOs;
    [SerializeField] private List<WeaponRowUI> weaponRows;

    [Header("Game Balance - Costs")]
    [SerializeField] private int rifleUnlockGold = 100;
    [SerializeField] private int smgUnlockGold = 200;
    [SerializeField] private int sniperUnlockGold = 300;

    [Space]
    [SerializeField] private int baseUpgradeGold = 50;
    [SerializeField] private int baseUpgradePart = 10;

    private PlayerData playerData;

    void Start()
    {
        if (DataSaver.Instance == null)
        {
            Debug.LogError("DataSaver not found!");
            return;
        }
        playerData = DataSaver.Instance.playerData;

        InitializeInventory();
        LinkDataToUI();
    }

    void InitializeInventory()
    {
        bool needsSave = false;

        foreach (GunSO so in allGunSOs)
        {
            string gunID = so.gunType.ToString();

            WeaponData existingData = playerData.inventory.Find(w => w.item_id == gunID);

            if (existingData == null)
            {
                WeaponData newData = new WeaponData();
                newData.item_id = gunID;
                newData.level = 1;

                if (so.gunType == GunType.Pistol)
                {
                    newData.is_unlocked = true;
                    newData.is_equipped = true;
                }
                else
                {
                    newData.is_unlocked = false;
                    newData.is_equipped = false;
                }

                playerData.inventory.Add(newData);
                needsSave = true;
            }
        }

        if (needsSave)
        {
            Debug.Log("Initializing player weapon inventory...");
            DataSaver.Instance.SaveDataFn();
        }
    }

    void LinkDataToUI()
    {
        foreach (WeaponRowUI row in weaponRows)
        {
            if (row.baseGunStats == null)
            {
                Debug.LogError("GunSO not assigned for row: " + row.gameObject.name);
                continue;
            }

            string gunID = row.baseGunStats.gunType.ToString();
            WeaponData data = playerData.inventory.Find(w => w.item_id == gunID);

            if (data != null)
            {
                row.Initialize(data, this);
            }
            else
            {
                Debug.LogError("No data found for gun: " + gunID);
            }
        }
    }

    private void RefreshAllRows()
    {
        foreach (WeaponRowUI row in weaponRows)
        {
            row.RefreshUI();
        }
    }

    public void AttemptUnlock(WeaponData weaponToUnlock)
    {
        int cost = 0;

        switch (weaponToUnlock.item_id)
        {
            case "Rifle": cost = rifleUnlockGold; break;
            case "SMG": cost = smgUnlockGold; break;
            case "Sniper": cost = sniperUnlockGold; break;
            default:
                Debug.LogWarning("Cannot unlock: " + weaponToUnlock.item_id);
                return;
        }

        if (playerData.gold >= cost)
        {
            playerData.gold -= cost;
            weaponToUnlock.is_unlocked = true;

            Debug.Log("Unlocked successfully: " + weaponToUnlock.item_id);
            DataSaver.Instance.SaveDataFn();
            RefreshAllRows();
        }
        else
        {
            Debug.Log("Not enough gold! Need " + cost);
        }
    }

    public void AttemptUpgrade(WeaponData weaponToUpgrade)
    {
        if (weaponToUpgrade.level >= 5)
        {
            Debug.Log(weaponToUpgrade.item_id + " has reached max level (5)!");
            return;
        }

        int goldCost = baseUpgradeGold * weaponToUpgrade.level;
        int partCost = baseUpgradePart * weaponToUpgrade.level;

        if (playerData.gold >= goldCost && playerData.part >= partCost)
        {
            playerData.gold -= goldCost;
            playerData.part -= partCost;
            weaponToUpgrade.level++;

            Debug.Log("Upgraded " + weaponToUpgrade.item_id + " to level " + weaponToUpgrade.level);
            DataSaver.Instance.SaveDataFn();
            RefreshAllRows();
        }
        else
        {
            Debug.Log("Not enough resources! Need " + goldCost + " gold and " + partCost + " parts.");
        }
    }

    public void AttemptEquip(WeaponData weaponToEquip)
    {
        foreach (WeaponData weapon in playerData.inventory)
        {
            weapon.is_equipped = false;
        }

        weaponToEquip.is_equipped = true;

        Debug.Log("Equipped: " + weaponToEquip.item_id);
        DataSaver.Instance.SaveDataFn();
        RefreshAllRows();
    }
}