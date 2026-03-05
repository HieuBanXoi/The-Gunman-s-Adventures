using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public TextMeshProUGUI logTxt;

    private PlayerData playerData;

    [Header("Level 1")]
    [SerializeField] private Button level1PlayButton;
    [Header("Level 2")]
    [SerializeField] private Button level2PlayButton;
    [SerializeField] private int level2Cost = 100;
    [SerializeField] private Button level2UnlockButton;
    [SerializeField] private GameObject level2BG;
    [SerializeField] private TextMeshProUGUI level2CostText;

    [Header("Level 3")]
    [SerializeField] private Button level3PlayButton;
    [SerializeField] private int level3Cost = 150;
    [SerializeField] private Button level3UnlockButton;
    [SerializeField] private GameObject level3BG;
    [SerializeField] private TextMeshProUGUI level3CostText;

    [Header("Level 4")]
    [SerializeField] private Button level4PlayButton;
    [SerializeField] private int level4Cost = 200;
    [SerializeField] private Button level4UnlockButton;
    [SerializeField] private GameObject level4BG;
    [SerializeField] private TextMeshProUGUI level4CostText;

    void Start()
    {
        if (DataSaver.Instance == null)
        {
            Debug.LogError("Không tìm th?y DataSaver.Instance!");
            return;
        }
        playerData = DataSaver.Instance.playerData;

        if (playerData.level == 0)
        {
            playerData.level = 1;
            DataSaver.Instance.SaveDataFn();
        }

        level2UnlockButton.onClick.AddListener(AttemptUnlockLevel2);
        level3UnlockButton.onClick.AddListener(AttemptUnlockLevel3);
        level4UnlockButton.onClick.AddListener(AttemptUnlockLevel4);


        level1PlayButton.onClick.AddListener(() => LoadLevel("Level1"));
        level2PlayButton.onClick.AddListener(() => LoadLevel("Level2"));
        level3PlayButton.onClick.AddListener(() => LoadLevel("Level3"));
        level4PlayButton.onClick.AddListener(() => LoadLevel("Level4"));

        UpdateAllUI();
    }

    void UpdateAllUI()
    {
        UIMainHallManager.Instance.UpdateResource();


        bool isLevel2Unlocked = (playerData.level >= 2);
        level2UnlockButton.gameObject.SetActive(!isLevel2Unlocked);
        level2BG.SetActive(!isLevel2Unlocked);
        level2PlayButton.gameObject.SetActive(isLevel2Unlocked);
        if (level2CostText != null) level2CostText.text = level2Cost.ToString();

        
        bool isLevel3Unlocked = (playerData.level >= 3);
        level3UnlockButton.gameObject.SetActive(!isLevel3Unlocked);
        level3BG.SetActive(!isLevel3Unlocked);
        level3PlayButton.gameObject.SetActive(isLevel3Unlocked);
        if (level3CostText != null) level3CostText.text = level3Cost.ToString();

        level3UnlockButton.interactable = isLevel2Unlocked;

        bool isLevel4Unlocked = (playerData.level >= 4);
        level4UnlockButton.gameObject.SetActive(!isLevel4Unlocked);
        level4BG.SetActive(!isLevel4Unlocked);
        level4PlayButton.gameObject.SetActive(isLevel4Unlocked);
        if (level4CostText != null) level4CostText.text = level4Cost.ToString();
 
        level4UnlockButton.interactable = isLevel3Unlocked;
    }


    public void AttemptUnlockLevel2()
    {
        if (playerData.gold >= level2Cost)
        {
            playerData.gold -= level2Cost;

            playerData.level = 2;

            Debug.Log("Level 2 unlocked");
            ShowLogMsg("Level 2 unlocked!");
            DataSaver.Instance.SaveDataFn();

            UpdateAllUI();
        }
        else
        {
            Debug.Log("Not enough gold! Need " + level2Cost);
            ShowLogMsg("Not enough gold! Need " + level2Cost);
        }
    }

    public void AttemptUnlockLevel3()
    {
        if (playerData.level < 2)
        {
            Debug.Log("You need unlock level 2 first");
            ShowLogMsg("You need unlock level 2 first");
            return;
        }

        if (playerData.gold >= level3Cost)
        {
            playerData.gold -= level3Cost;
            playerData.level = 3;
            Debug.Log("Level 3 unlocked");
            ShowLogMsg("Level 3 unlocked!");
            DataSaver.Instance.SaveDataFn();
            UpdateAllUI();
        }
        else
        {
            Debug.Log("Not enough gold! Need " + level3Cost);
            ShowLogMsg("Not enough gold! Need " + level3Cost);
        }
    }

    public void AttemptUnlockLevel4()
    {
        if (playerData.level < 3)
        {   
            Debug.Log("You need unlock level 3 first");
            ShowLogMsg("You need unlock level 3 first");
            return;
        }

        if (playerData.gold >= level4Cost)
        {
            playerData.gold -= level4Cost;
            playerData.level = 4;
            Debug.Log("Level 4 unlocked");
            ShowLogMsg("Level 4 unlocked!");
            DataSaver.Instance.SaveDataFn();
            UpdateAllUI();
        }
        else
        {
            Debug.Log("Not enough gold! Need " + level4Cost);
            ShowLogMsg("Not enough gold! Need " + level4Cost);
        }
    }
    public void LoadLevel(string sceneName)
    {
        if (string.IsNullOrEmpty(sceneName))
        {
            Debug.LogError("Scene name not found");
            ShowLogMsg("Scene name not found");
            return;
        }

        Debug.Log("Loading scene: " + sceneName);
        SceneManager.LoadScene(sceneName);
    }
    void ShowLogMsg(string msg)
    {
        StopCoroutine(nameof(FadeOutLog));
        logTxt.text = msg;
        logTxt.color = new Color(logTxt.color.r, logTxt.color.g, logTxt.color.b, 1f);
        float[] timings = new float[] { 5.0f, 1.0f };
        StartCoroutine(nameof(FadeOutLog), timings);
    }

    private IEnumerator FadeOutLog(object param)
    {
        float[] timings = (float[])param;
        float delay = timings[0];
        float fadeTime = timings[1];

        yield return new WaitForSeconds(delay);

        float timer = 0f;
        Color startColor = logTxt.color;

        while (timer < fadeTime)
        {
            float alpha = Mathf.Lerp(1f, 0f, timer / fadeTime);
            logTxt.color = new Color(startColor.r, startColor.g, startColor.b, alpha);

            timer += Time.deltaTime;
            yield return null;
        }

        logTxt.color = new Color(startColor.r, startColor.g, startColor.b, 0f);
    }
}