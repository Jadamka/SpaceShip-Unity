using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    Rigidbody2D rb;

    public float force = 20f;

    public int score;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddRelativeForce(Vector2.right * force, ForceMode2D.Force);
        Destroy(gameObject, 5f);
        score = 0;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Enemy")
        {
            Destroy(gameObject);
            score = 20;
            GameObject.Find("GameManager").SendMessage("ScoreText", score);
            GameObject.Find("Spawner").SendMessage("ScoreCount", score);
        }
        if(col.tag == "Boss")
        {
            Destroy(gameObject);
        }
    }
}
