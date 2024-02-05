using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarDestroyer : MonoBehaviour
{
    
    public BoxCollider2D bc;
    public GameManager manager = null;

    private void Awake()
    {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            manager.score += manager.playerSpeed;
            
            Destroy(collision.gameObject);
            if(manager.score >= manager.hiScore)
            {
                manager.hiScore = manager.score;
            }
        }


        if (collision.gameObject.tag == "Tree")
        {
            Destroy(collision.gameObject);
        }
    }
}
