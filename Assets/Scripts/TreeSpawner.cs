using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSpawner : MonoBehaviour
{
    
    public float spawnTimeRoad = 1f;

    float rndTime;
    int rndPos;

    public GameObject tree;
    public GameObject roadPiece;
    public GameManager manager = null;

    private void Awake()
    {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Start()
    {
        Instantiate(roadPiece, new Vector3(-4.5f, 0, 0), Quaternion.identity);

        Roll();
        Invoke("SpawnTree", rndTime);
        Invoke("SpawnRoad", spawnTimeRoad);


    }

    private void Update()
    {
        if(rndTime <= 0)
        {
            rndTime = 0.1f;
        }
        if(spawnTimeRoad <= 0)
        {
            spawnTimeRoad = 0.1f;
        }
    }

    void SpawnTree()
    {
        if(rndPos > 25)
        {
            Instantiate(tree, new Vector3(-8.1f, 8, 0), Quaternion.identity);
            Roll();
        }
        if(rndPos <= 25)
        {
            Instantiate(tree, new Vector3(-0.9f, 8, 0), Quaternion.identity);
            Roll();
        }
        
        Invoke("SpawnTree", rndTime);
    }

    void SpawnRoad()
    {
        Instantiate(roadPiece, new Vector3(-4.5f, 8, 0), Quaternion.identity);
        Invoke("SpawnRoad", spawnTimeRoad);
    }

    void Roll()
    {
        rndTime = Random.Range(1f, 3f);
        rndPos = Random.Range(0, 50);
    }
}
