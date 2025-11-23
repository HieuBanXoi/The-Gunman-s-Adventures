using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WeaponRowUI : MonoBehaviour
{
    [Header("Data")]
    public GunSO baseGunStats;

    [Header("UI References")]
    [SerializeField] private TextMeshProUGUI damageTxt;
    [SerializeField] private TextMeshProUGUI speedTxt;
    [SerializeField] private TextMeshProUGUI levelTxt;
    [SerializeField] private Button upgradeBtn;
    [SerializeField] private Button equipBtn;
    [SerializeField] private TextMeshProUGUI equipBtnTxt;
    [SerializeField] private GameObject equipBG;
    [SerializeField] private GameObject lockGroup;
    [SerializeField] private Button unlockBtn;

    private WeaponData weaponData;
    private WeaponUIManager manager;

    public void Initialize(WeaponData data, WeaponUIManager mgr)
    {
        this.weaponData = data;
        this.manager = mgr;

        upgradeBtn.onClick.AddListener(OnUpgrade);
        equipBtn.onClick.AddListener(OnEquip);
        unlockBtn.onClick.AddListener(OnUnlock);

        RefreshUI();
    }

    public void RefreshUI()
    {
        bool isUnlocked = weaponData.is_unlocked;
        lockGroup.SetActive(!isUnlocked);
  
        if (isUnlocked)
        {

            float currentDamage = baseGunStats.damage + (weaponData.level - 1) * 5; 
            float currentFireTime = baseGunStats.fireSpeed - (weaponData.level - 1) * 0.1f; 
            currentFireTime = Mathf.Max(currentFireTime, 0.1f);

            
            float roundsPerSecond = 1f / currentFireTime;

            damageTxt.text = currentDamage.ToString("F0");
            speedTxt.text = roundsPerSecond.ToString("F1");
            levelTxt.text = weaponData.level.ToString();



            if (weaponData.level >= 5)
            {
                upgradeBtn.gameObject.SetActive(true);
                upgradeBtn.interactable = false;
                var upgradeBtnText = upgradeBtn.GetComponentInChildren<TextMeshProUGUI>();
                if (upgradeBtnText != null) upgradeBtnText.text = "MAX";
            }
            else
            {
                upgradeBtn.gameObject.SetActive(true);
                upgradeBtn.interactable = true;
                var upgradeBtnText = upgradeBtn.GetComponentInChildren<TextMeshProUGUI>();
                if (upgradeBtnText != null) upgradeBtnText.text = "UPGRADE";
            }

            equipBtn.gameObject.SetActive(isUnlocked);
            if (weaponData.is_equipped)
            {
                equipBtnTxt.text = "EQUIPPED";
                equipBtn.interactable = false;
                equipBG.SetActive(true);
            }
            else
            {
                equipBtnTxt.text = "EQUIP";
                equipBtn.interactable = true;
                equipBG.SetActive(false);
            }
        }
        else
        {
            damageTxt.text = baseGunStats.damage.ToString("F0");
            speedTxt.text = (1f / baseGunStats.fireSpeed).ToString("F1");
            levelTxt.text = "1";
        }
        UIMainHallManager.Instance.UpdateResource();
    }

    private void OnUpgrade()
    {
        manager.AttemptUpgrade(weaponData);
    }

    private void OnEquip()
    {
        manager.AttemptEquip(weaponData);
    }

    private void OnUnlock()
    {
        manager.AttemptUnlock(weaponData);
    }
}