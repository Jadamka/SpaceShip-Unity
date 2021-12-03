using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeam : MonoBehaviour
{

    public float speed = 3f;
    GameObject attackPoint;

    void Start()
    {
        attackPoint = GameObject.Find("AttackPoint");
        transform.position = new Vector2(transform.position.x, -.8f);
        Destroy(gameObject, .75f);
    }

    void Update()
    {
        Vector2 attackPos = new Vector2(attackPoint.transform.position.x, transform.position.y);

        transform.position = Vector2.MoveTowards(transform.position, attackPos, speed * Time.deltaTime);
    }
}
