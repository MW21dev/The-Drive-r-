using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    
    public float speed = 1f;

    public Rigidbody2D rb;
    public GameManager manager = null;

    private void Awake()
    {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    void Update()
    {
        rb.AddForce(-transform.up * (speed * manager.playerSpeed) * 10f * Time.deltaTime);
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, speed * manager.playerSpeed * 10f);
    }

    
}
