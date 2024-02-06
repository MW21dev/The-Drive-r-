using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeMove : MonoBehaviour
{
    
    public float speed = 1f;

    public Rigidbody2D rb;

    public GameManager manager = null;

    private void Awake()
    {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    void FixedUpdate()
    {
        rb.velocity = new Vector2(0, -1 * speed * (manager.playerSpeed * 0.5f) * Time.fixedDeltaTime) * 100;

        //rb.AddForce(-transform.up * (speed * manager.playerSpeed) * 10f * Time.deltaTime);
        //.velocity = Vector3.ClampMagnitude(rb.velocity, speed * manager.playerSpeed * 10f);
    }
}
