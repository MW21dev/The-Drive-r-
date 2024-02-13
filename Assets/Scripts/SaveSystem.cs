using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ScoreData
{
    public float recordScore = 0;
}
public class SaveSystem : MonoBehaviour
{
    public GameManager manager;
    public ScoreData scoreData;
    string saveFilePath;

    private void Start()
    {
        scoreData = new ScoreData();
        scoreData.recordScore = 0;

        manager = GameObject.Find("GameManager").GetComponent<GameManager>();

        saveFilePath = Application.persistentDataPath + "/SaveData.json";
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F3))
        {
            ResetSave();
        }
    }

    public void SaveGame()
    {
        string saveData = JsonUtility.ToJson(scoreData);

        if (manager.hiScore >= scoreData.recordScore)
        {
            File.WriteAllText(saveFilePath, saveData);
        }


    }

    public void LoadGame()
    {
        if (File.Exists(saveFilePath))
        {
            string loadScoreData = File.ReadAllText(saveFilePath);
            scoreData = JsonUtility.FromJson<ScoreData>(loadScoreData);
        }
        else
        {
            Debug.Log("no save file");
        }
    }

    public void ResetSave()
    {
        if (File.Exists(saveFilePath))
        {
            File.Delete(saveFilePath);
        }
        else
        {
            Debug.Log("no save file");
        }
    }
}
