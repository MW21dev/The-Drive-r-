using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class Menu : MonoBehaviour
{

    public SoundManager soundManager = null;
    public ParticleSystem p1 = null;
    public ParticleSystem p2 = null;
    public ParticleSystem p3 = null;
    public ParticleSystem p4 = null;

    void Start()
    {
        Time.timeScale = 1;
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        
    }

    public void GameStart()
    {
        soundManager.PlaySound(2);
        Time.timeScale = 1;
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }



    public void Exit()
    {
        soundManager.PlaySound(2);
        Application.Quit();
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#endif
    }
}
