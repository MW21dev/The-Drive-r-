using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    public float spawnTime = 3f;


    public GameObject enemy;

    int rnd;

    public GameManager manager = null;

    private void Awake()
    {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }


    void Start()
    {
        
        Invoke("Spawn", spawnTime);
        Roll();
    }

    void Spawn()
    {
        

        if(rnd < 25)
        {
            Instantiate(enemy, new Vector3(-5.7f, 8, 0), Quaternion.identity);
        }
        else if (rnd > 25)
        {
            Instantiate(enemy, new Vector3(-3.3f, 8, 0), Quaternion.identity);
        }

        Roll();
        Invoke("Spawn", spawnTime);
    }

    void Roll()
    {
        rnd = Random.Range(0, 50);
    }
}
