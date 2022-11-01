using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour
{
    // Start() and Update() methods deleted - we don't need them right now

    public static GameManager Instance;

    public string playerName;
    public string bestScoreName;
    public int bestScore;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadBestScore();
    }

    [System.Serializable]
    class SaveData
    {
        public string BestScoreName;
        public int BestScore;
    }

    public void SaveBestScore()
    {
        SaveData data = new SaveData();
        data.BestScoreName = bestScoreName;
        data.BestScore = bestScore;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadBestScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        Debug.Log("File: " + path);
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            bestScoreName = data.BestScoreName;
            bestScore = data.BestScore;
        }
    }
}