using TMPro;
using UnityEngine;

public class UIPartAndCoin : CoreMonoBehaviour
{
    private PlayerData playerData;
    private static UIPartAndCoin instance;
    public static UIPartAndCoin Instance { get => instance; }

    [SerializeField] private TextMeshProUGUI countGold;
    [SerializeField] private TextMeshProUGUI countPart;

    protected bool isOpen = false;
    protected override void Awake()
    {
        base.Awake();
        if (UIPartAndCoin.instance != null) Debug.LogError("Only 1 UIPartAndCoin allow to exist");
        UIPartAndCoin.instance = this;
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
}
