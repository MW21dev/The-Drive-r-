using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    public float spawnTime = 0f;


    public GameObject enemy;
    public GameObject enemy2;

    int rndPose;
    int rndEnemy;
    float rndScooterPose;

    public GameManager manager = null;

    private void Awake()
    {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    void Start()
    {
        
        Roll();
        
    }

    private void Update()
    {
        spawnTime += Time.deltaTime;

        if(spawnTime >= 3f)
        {
            spawnTime = 3f;
        }

        if(spawnTime == 3f)
        {
            Spawn();
            spawnTime = 0f;
        }
    }


    void Spawn()
    {
        
        if (rndEnemy < 3)
        {
            Instantiate(enemy2, new Vector3(rndScooterPose, 9, 0), Quaternion.identity);
        }
        else if(rndEnemy >= 3)
        {
            if (rndPose < 25)
            {
                Instantiate(enemy, new Vector3(-5.7f, 8, 0), Quaternion.identity);
            }
            else if (rndPose > 25)
            {
                Instantiate(enemy, new Vector3(-3.3f, 8, 0), Quaternion.identity);
            }
        }

        Roll();
        
    }

    void Roll()
    {
        rndPose = Random.Range(0, 50);
        rndEnemy = Random.Range(0, 10);
        rndScooterPose = Random.Range(-6.5f, -2.5f);
    }
}
