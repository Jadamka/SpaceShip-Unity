using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 12;

    public GameObject laser;
    public GameObject attackPoint;
    bool readyToShoot = true;

    float screenBlock;

    public GameObject deathText;

    public AudioSource tickSource;

    void Start()
    {
        screenBlock = Camera.main.aspect * Camera.main.orthographicSize - transform.localScale.x * 2f;
    }

    void Update()
    {
        Move();
        ScreenBlocking();
        Shoot();
    }

    void Move()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float velocityX = inputX * speed;
        transform.Translate(Vector2.right * velocityX * Time.deltaTime);
    }

    void ScreenBlocking()
    {
        if(transform.position.x > screenBlock)
        {
            transform.position = new Vector2(screenBlock, transform.position.y);
        }
        if(transform.position.x < -screenBlock)
        {
            transform.position = new Vector2(-screenBlock, transform.position.y);
        }
    }

    void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space) && readyToShoot)
        {
            tickSource.Play();
            Instantiate(laser, attackPoint.transform.position, Quaternion.Euler(0f, 0f, 90f));
            readyToShoot = false;
            Invoke(nameof(ResetShot), .25f);
        }
    }

    void ResetShot()
    {
        readyToShoot = true;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Enemy")
        {
            deathText.SetActive(true);
            Time.timeScale = 0;
            Destroy(gameObject);
        }

        if (col.tag == "LaserBeam")
        {
            deathText.SetActive(true);
            Time.timeScale = 0;
            Destroy(gameObject);
        }
    }
}
