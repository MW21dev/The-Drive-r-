using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform player;
    public Rigidbody2D rb;
    public float speed = 2f;
    public bool invincible = false;



    public GameManager manager = null;
    public SoundManager soundManager = null;
    public StatsManager statsManager = null;
    
    public ParticleSystem pr;

    private void Awake()
    {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        soundManager = GameObject.Find("SoundManager").GetComponent <SoundManager>();
        statsManager = GameObject.Find("Canvas").GetComponent<StatsManager>();

        statsManager.driverSmash.enabled = false;
    }


    void FixedUpdate()
    {
        float moveX = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(moveX * speed * Time.fixedDeltaTime, 0) * 100;

        if(moveX > 0)
        {
            statsManager.driver.enabled = false;
            statsManager.driverR.enabled = false;
            statsManager.driverL.enabled = true;

            transform.rotation = Quaternion.Euler(0, 0, -5);
            //ojler
        }
        if(moveX < 0)
        {
            statsManager.driver.enabled = false;
            statsManager.driverL.enabled = false;
            statsManager.driverR.enabled = true;

            transform.rotation = Quaternion.Euler(0, 0, 5);

        }
        if (moveX == 0)
        {
            statsManager.driverR.enabled = false;
            statsManager.driverL.enabled = false;
            statsManager.driver.enabled = true;

            transform.rotation = Quaternion.identity;

        }


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!invincible)
        {
            if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Barier")
            {
                statsManager.driverSmash.enabled = true;
                pr.Play();
                soundManager.PlaySound(0);

                manager.hp -= 1;


                manager.playerSpeed = 1;

                manager.score = 0;

                player.transform.position = new Vector3(-3, -3, 0);


                ClearEnemies();
                Invoke("ClearSmash", 1);
                invincible = true;

            }
        }
        
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!invincible)
        {
            if (collision.gameObject.tag == "Barier")
            {
                statsManager.driverSmash.enabled = true;
                pr.Play();
                soundManager.PlaySound(0);

                manager.hp -= 1;


                manager.playerSpeed = 1;

                manager.score = 0;

                player.transform.position = new Vector3(-3, -3, 0);


                ClearEnemies();
                Invoke("ClearSmash", 1);
                invincible = true;

            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!invincible)
        {
            if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Barier")
            {
                statsManager.driverSmash.enabled = true;
                pr.Play();
                soundManager.PlaySound(0);

                manager.hp -= 1;


                manager.playerSpeed = 1;

                manager.score = 0;

                player.transform.position = new Vector3(-3, -3, 0);


                ClearEnemies();
                Invoke("ClearSmash", 1);
                invincible = true;

            }
        }
    }

    public void ClearEnemies()
    {
        

        GameObject[] enemies;
        enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemy in enemies)
        {
            Destroy(enemy);
        }

        GameObject[] trees;
        trees = GameObject.FindGameObjectsWithTag("Tree");

        foreach (GameObject tree in trees)
        {
            Destroy(tree);
        }


    }

    void ClearSmash()
    {
        statsManager.driverSmash.enabled = false;
        invincible = false;
    }
}
