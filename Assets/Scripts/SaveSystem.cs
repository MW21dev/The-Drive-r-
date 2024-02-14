using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SaveSystem : MonoBehaviour
{
    public GameManager manager;
    
    private void Start()
    {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        
        
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
        PlayerPrefs.SetFloat("RecordScore", manager.recordScore);
    }

    public void LoadGame()
    {
        manager.recordScore = PlayerPrefs.GetFloat("RecordScore");
    }

    public void ResetSave()
    {
        manager.recordScore = 0;
        SaveGame();
    }
}
