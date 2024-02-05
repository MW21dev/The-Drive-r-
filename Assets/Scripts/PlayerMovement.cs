using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform player;
    public Rigidbody2D rb;
    bool invincible = false;
    float speed = 2f;



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
        }
        if(moveX < 0)
        {
            statsManager.driver.enabled = false;
            statsManager.driverL.enabled = false;
            statsManager.driverR.enabled = true;
        }
        if(moveX == 0)
        {
            statsManager.driverR.enabled = false;
            statsManager.driverL.enabled = false;
            statsManager.driver.enabled = true;
        }
 
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Barier" && !invincible)
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
