using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Firebase.Database;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

[Serializable]
public class WeaponData
{
    public string item_id;
    public int level;
    public bool is_equipped;
    public bool is_unlocked;
}

[Serializable]
public class PlayerData
{
    public string username;
    public int level;
    public int gold;
    public int part;

    public List<WeaponData> inventory = new();
}

public class DataSaver : MonoBehaviour
{
    private static DataSaver instance;
    public static DataSaver Instance { get => instance; }
    public PlayerData playerData;
    public string userId;
    DatabaseReference dbRef;

    private void Awake()
    {
        dbRef = FirebaseDatabase.DefaultInstance.RootReference;
        if (DataSaver.instance != null) Debug.LogError("Only 1 DataSaver allow to exist");
        DataSaver.instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    public void SaveDataFn()
    {
        string json = JsonUtility.ToJson(playerData);
        dbRef.Child("users").Child(userId).SetRawJsonValueAsync(json).ContinueWith(task =>
        {
            if (task.IsFaulted)
            {
                Debug.LogError("Save failed: " + task.Exception);
            }
            else if (task.IsCompletedSuccessfully)
            {
                Debug.Log("Save successful!");
            }
        });
    }

    public void LoadDataFn(Action onCompleteCallback = null)
    {
        StartCoroutine(LoadDataEnum(onCompleteCallback));
    }

    IEnumerator LoadDataEnum(Action onCompleteCallback = null)
    {
        var serverData = dbRef.Child("users").Child(userId).GetValueAsync();
        yield return new WaitUntil(predicate: () => serverData.IsCompleted);

        print("process is complete");

        DataSnapshot snapshot = serverData.Result;
        string jsonData = snapshot.GetRawJsonValue();

        if (jsonData != null)
        {
            print("server data found");
            playerData = JsonUtility.FromJson<PlayerData>(jsonData);
        }
        else
        {
            print("no data found");
        }

        onCompleteCallback?.Invoke();
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene("MainHall");
    }
    public int PlayerLevel
    {
        get
        {
            if (playerData == null)
            {
                Debug.LogWarning("PlayerData is null. Returning level 0.");
                return 0;
            }
            return playerData.level;
        }
    }
}