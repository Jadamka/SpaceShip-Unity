using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 15f;

    public Collider2D M_collider;
    public SpriteRenderer M_sprite;
    public AudioSource tickSource;

    public GameObject explosion;

    void Start()
    {
        Destroy(gameObject, 3f);
    }

    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Laser")
        {
            M_collider.enabled = !M_collider.enabled;
            M_sprite.enabled = !M_sprite.enabled;
            tickSource.Play();
            Instantiate(explosion, transform.position, Quaternion.identity);
        }
    }
}
