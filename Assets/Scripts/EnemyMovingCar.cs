using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovingCar : MonoBehaviour
{
    public Vector3 startPosition;
    
    public Rigidbody2D rb;
    public GameManager manager = null;
    public float speed = 1f;
    public float width = 1f;
    bool right = false;
    bool left = false;

    private void Start()
    {
        startPosition = transform.position;
        if(startPosition.x == -5.7f)
        {
            left = true;
        }
        if(startPosition.x == -3.3f)
        {
            right = true;
        }
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    private void FixedUpdate()
    {
       
        if (left)
        {
            
            rb.AddForce(new Vector2(width, -0.5f) * speed * manager.playerSpeed);
        }
        if (right)
        {
            
            rb.AddForce(new Vector2(-width, -0.5f) * speed * manager.playerSpeed);
        }

        if (transform.position.x < -6f)
        {
            left =false; right =false;
            rb.AddForce(new Vector2(0, 0));
            
        }
        if (transform.position.x > -3f)
        {
            left = false; right = false;
            rb.AddForce(new Vector2(0, 0));

        }

    }
}
