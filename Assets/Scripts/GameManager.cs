using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public SaveData bestScore;
    public string username = "";
    public int score = 0;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        LoadHighScore();
    }

    [System.Serializable]
    public class SaveData
    {
        public string username;
        public int score;
    }

    public void SaveHighScore(int newScore)
    {
        if (newScore > bestScore.score) {
            SaveData data = new SaveData();
            data.username = username;
            data.score = newScore;
            bestScore = data;

            string json = JsonUtility.ToJson(data);

            File.WriteAllText(Application.persistentDataPath + "/bestScore.json", json);
        }
    }

    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/bestScore.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            bestScore = data;
        }
    }
}
