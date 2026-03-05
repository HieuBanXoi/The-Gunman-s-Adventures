using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIMainHallManager : CoreMonoBehaviour
{
    private PlayerData playerData;
    private static UIMainHallManager instance;
    public static UIMainHallManager Instance { get => instance; }

    [SerializeField] private GameObject levelSelection;
    [SerializeField] private GameObject inventory;
    [SerializeField] private TextMeshProUGUI countGold;
    [SerializeField] private TextMeshProUGUI countPart;

    protected bool isOpen = false;
    protected override void Awake()
    {
        base.Awake();
        if (UIMainHallManager.instance != null) Debug.LogError("Only 1 UIManager allow to exist");
        UIMainHallManager.instance = this;
    }
    protected override void Start()
    {
        base.Start();
        if (DataSaver.Instance == null)
        {
            Debug.LogError("Không tìm th?y DataSaver.Instance!");
            return;
        }
        playerData = DataSaver.Instance.playerData;

        this.UpdateResource();
    }
    public void UpdateResource()
    {
        this.UpdateGold();
        this.UpdatePart();
    }
    protected void UpdateGold()
    {
        if (this.countGold != null && this.playerData != null)
        {
            this.countGold.text = this.playerData.gold.ToString();
        }
    }
    protected void UpdatePart()
    {
        if (this.countPart != null && this.playerData != null)
        {
            this.countPart.text = this.playerData.part.ToString();
        }
    }
    public virtual void InvToggle()
    {
        this.isOpen = !this.isOpen;
        if (this.isOpen) this.Open();
        else this.Close();
    }
    public virtual void Open()
    {
        this.inventory.SetActive(true);
        this.levelSelection.SetActive(false);
        this.isOpen = true;
    }
    public virtual void Close()
    {
        this.inventory.SetActive(false);
        this.levelSelection.SetActive(true);
        this.isOpen = false;
    }
    
}