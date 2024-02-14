using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform player;
    public Rigidbody2D rb;
    public float speed = 2f;
    public bool invincible = false;
    public bool shield = false;

    public GameObject shieldSprite = null;
    public GameManager manager = null;
    public SoundManager soundManager = null;
    public StatsManager statsManager = null;
    public PickUpEffect pickUpEffect = null;
    
    public ParticleSystem pr;

    private void Start()
    {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        soundManager = GameObject.Find("SoundManager").GetComponent <SoundManager>();
        statsManager = GameObject.Find("Canvas").GetComponent<StatsManager>();

        statsManager.driverSmash.enabled = false;
        shieldSprite.SetActive(false);
    }

    private void Update()
    {
        if (shield)
        {
            shieldSprite.SetActive(true);
        }
        else
        {
            shieldSprite.SetActive(false);
        }

        if (!invincible)
        {
            shield = false;
        }
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
        if (collision.gameObject.tag == "Enemy")
        {
            if (shield)
            {
                Destroy(collision.gameObject);
                pr.Play();
                soundManager.PlaySound(0);
                invincible = false;
            }
            else
            {
                if (!invincible)
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

           

        if (collision.gameObject.tag == "PickUp")
        {
            pickUpEffect = collision.gameObject.GetComponent<PickUpEffect>();

            switch (pickUpEffect.pickUp)
            {
                case 1:
                    manager.hp += 1;
                    soundManager.PlaySound(2);
                    Destroy(collision.gameObject);
                    break;
                case 2:
                    invincible = true;
                    shield = true;
                    soundManager.PlaySound(2);
                    Destroy(collision.gameObject);
                    break;
                case 3:
                    manager.playerSpeed -= 1;
                    soundManager.PlaySound(3);
                    break;
            }

        }


    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Barier")
        {
            if (shield)
            {
                
                pr.Play();
                soundManager.PlaySound(0);
                invincible = false;
            }
            else
            {
                if (!invincible)
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
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Barier")
        {
            if (shield)
            {
                
                pr.Play();
                soundManager.PlaySound(0);
                invincible = false;
            }
            else
            {
                if (!invincible)
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

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (shield)
            {
                Destroy(collision.gameObject);
                pr.Play();
                soundManager.PlaySound(0);
                invincible = false;
            }
            else
            {
                if (!invincible)
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
