using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSpawner : MonoBehaviour
{
    public GameObject healthUp;
    public GameObject shield;
    public GameObject slowDown;

    float spawnTime;

    int rndPickUp;
    int rndChance;
    int rndPose;

    private void Start()
    {
        Roll();
    }

    private void Update()
    {
        spawnTime += Time.deltaTime;

        if(spawnTime >= 2f)
        {
            spawnTime = 2f;
        }
       
        if(spawnTime == 2f)
        {
            Roll();
            Spawn();
        }
    }

    void Spawn()
    {
        if (rndChance < 2)
        {
            if (rndPickUp == 0)
            {
                if (rndPose == 0)
                {
                    Instantiate(healthUp, new Vector3(-5.7f, 10, 0), Quaternion.identity);
                }
                else if (rndPose == 1)
                {
                    Instantiate(healthUp, new Vector3(-3.3f, 10, 0), Quaternion.identity);
                }
            }
            else if (rndPickUp == 1)
            {
                if (rndPose == 0)
                {
                    Instantiate(shield, new Vector3(-5.7f, 10, 0), Quaternion.identity);
                }
                else if (rndPose == 1)
                {
                    Instantiate(shield, new Vector3(-3.3f, 10, 0), Quaternion.identity);
                }
            }
            else if (rndPickUp == 2)
            {
                if (rndPose == 0)
                {
                    Instantiate(slowDown, new Vector3(-5.7f, 10, 0), Quaternion.identity);
                }
                else if (rndPose == 1)
                {
                    Instantiate(slowDown, new Vector3(-3.3f, 10, 0), Quaternion.identity);
                }
            }
        }

        spawnTime = 0f;
        
    }
    private void Roll()
    {
        rndChance = Random.Range(0, 10);
        rndPickUp = Random.Range(0, 3);
        rndPose = Random.Range(0, 2);
    }


}
