using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpEffect : MonoBehaviour
{
    public int pickUp;

    public GameManager manager;
    public PlayerMovement player;

    private void Start()
    {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        player = GameObject.Find("PlayerCar").GetComponent<PlayerMovement>();
    }

    
   
}
