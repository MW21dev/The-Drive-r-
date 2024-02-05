using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class StatsManager : MonoBehaviour
{
    public TMP_Text scoreNb;
    public TMP_Text hiScoreNb;
    public TMP_Text speedNb;
    public TMP_Text finalHiScoreNb;
    public GameManager manager = null;

    public Image Hp3;
    public Image Hp2;
    public Image Hp1;

    public Image driver;
    public Image driverR;
    public Image driverL;
    public Image driverSmash;


    
    private void Start()
    {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();

        scoreNb.text = manager.score.ToString();
        hiScoreNb.text = manager.hiScore.ToString();
        speedNb.text = manager.playerSpeed.ToString();

    }

    private void Update()
    {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();

        scoreNb.text = manager.score.ToString();
        hiScoreNb.text = manager.hiScore.ToString();
        speedNb.text = manager.playerSpeed.ToString();
        finalHiScoreNb.text = manager.hiScore.ToString();

        if (manager.hp < 3)
        {
            Hp3.enabled = false;
            if (manager.hp < 2)
            {
                Hp2.enabled = false;
                if(manager.hp < 1)
                {
                    Hp1.enabled = false;
                }
            }
        }

    }

}
