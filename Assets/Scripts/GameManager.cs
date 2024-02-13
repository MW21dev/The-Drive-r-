using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float playerSpeed = 1f;

    public float score = 0;
    public float hiScore = 0;
    public int hp = 3;

    public float slowCd = 0;

    public SoundManager soundManager = null;
    public MusicManager musicManager = null;
    public StatsManager statsManager = null;
    public SaveSystem saveSystem = null;
    public GameObject lose = null;
    public GameObject pause = null;
    public ParticleSystem speedParticleW = null;
    public ParticleSystem speedParticleC = null;

    void Start()
    {
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        musicManager = GameObject.Find("MusicManager").GetComponent<MusicManager>();
        statsManager = GameObject.Find("Canvas").GetComponent <StatsManager>();
        saveSystem = GameObject.Find("SaveSystem").GetComponent<SaveSystem>();
        lose = GameObject.Find("Lose");
        pause = GameObject.Find("Pause");
        

        lose.SetActive(false);
        pause.SetActive(false);
        musicManager.PlayMusic();
        saveSystem.LoadGame();
        Time.timeScale = 1;

    }

    
    void Update()
    {
        slowCd += Time.deltaTime;

        if(slowCd >= 2f)
        {
            slowCd = 2f;
        }
        
        if(hiScore >= saveSystem.scoreData.recordScore)
        {
            saveSystem.scoreData.recordScore = hiScore;
        }
        Debug.Log(saveSystem.scoreData.recordScore);
        
        if(!pause.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) || (Input.GetKeyDown(KeyCode.W)) && playerSpeed != 15)
            {
                playerSpeed++;
                soundManager.PlaySound(1);
            }
            /*if (slowCd == 2f && playerSpeed > 1)
            {
                if (Input.GetKeyDown(KeyCode.DownArrow) || (Input.GetKeyDown(KeyCode.S)))
                {
                    playerSpeed--;
                    soundManager.PlaySound(3);
                    slowCd = 0;
                }
            }
            */
        }
       
        if(playerSpeed > 15f)
        {
            playerSpeed = 15f;
        }

        if(hp < 1)
        {
            Time.timeScale = 0;

            lose.SetActive(true);
            saveSystem.LoadGame();
            musicManager.StopMusic();

        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pause.activeSelf)
            {
                Resume();
            }
            else
            {
                pause.SetActive(true);
            }
        }

        if (pause.activeSelf)
        {
            Time.timeScale = 0;
            musicManager.PauseMusic();
        }

        if(playerSpeed >= 6)
        {
            speedParticleW.Play();
        }
        

        if(playerSpeed >= 10)
        {
            speedParticleC.Play();
        }

        if(playerSpeed < 6)
        {
            speedParticleW.Stop();
            speedParticleC.Stop();
        }
    }

    public void Restart()
    {
        soundManager.PlaySound(2);
        Time.timeScale = 1;
        
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }



    public void Exit()
    {
        soundManager.PlaySound(2);
        
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);

    }

    public void Resume()
    {
        soundManager.PlaySound(2);
        Time.timeScale = 1;
        pause.SetActive(false);
        musicManager.UnPauseMusic();
    }

    
}
