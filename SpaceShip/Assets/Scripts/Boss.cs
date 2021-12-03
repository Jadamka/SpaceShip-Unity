using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{

    GameObject player;
    public float speed = 8f;

    public int health = 100;
    public GameObject explosion;

    public GameObject attackPoint;
    public GameObject laserBeam;
    public bool readyToAttack;

    void Start()
    {
        player = GameObject.Find("SpaceShip");
        readyToAttack = false;
        StartCoroutine(nameof(wait));
    }

    void Update()
    {
        Vector2 playerPos = new Vector2(player.transform.position.x, 2.8f);

        transform.position = Vector2.MoveTowards(transform.position, playerPos,  speed * Time.deltaTime);

        if (health <= 0)
        {
            Destroy(gameObject);
        }

        Attack();
    }

    void Attack()
    {
        if (readyToAttack)
        {
            Instantiate(laserBeam, attackPoint.transform.position, Quaternion.Euler(0f, 0f, 90f));
            readyToAttack = false;
            Invoke(nameof(ResetAttack), 2f);
        }
    }
    
    void ResetAttack()
    {
        readyToAttack = true;
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(3f);
        readyToAttack = true;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Laser")
        {
            health -= 5;
        }
    }
}
