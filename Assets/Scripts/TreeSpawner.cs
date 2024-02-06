using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSpawner : MonoBehaviour
{
    public float spawnTimeTree = 3f;
    public float spawnTimeRoad = 1f;

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

        Invoke("SpawnTree", spawnTimeTree);
        Invoke("SpawnRoad", spawnTimeRoad);


    }

    private void Update()
    {
        if(spawnTimeTree <= 0)
        {
            spawnTimeTree = 0.1f;
        }
        if(spawnTimeRoad <= 0)
        {
            spawnTimeRoad = 0.1f;
        }
    }

    void SpawnTree()
    {
        Instantiate(tree, new Vector3(-8.2f, 8, 0), Quaternion.identity);
        Instantiate(tree, new Vector3(-0.8f, 8, 0), Quaternion.identity);


        Invoke("SpawnTree", spawnTimeTree);
    }

    void SpawnRoad()
    {
        Instantiate(roadPiece, new Vector3(-4.5f, 8, 0), Quaternion.identity);
        Invoke("SpawnRoad", spawnTimeRoad);
    }

    
}
