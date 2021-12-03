using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject boss;
    public GameObject enemy;
    public float spawnTime = 1f;

    Vector2 screenSpawn;

    int scoreNumber = 0;

    bool bossReady = true;

    void Start()
    {
        screenSpawn = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
    }

    void Update()
    {
        if(Time.time > spawnTime && scoreNumber <= 280)
        {
            Vector2 spawnPos = new Vector2(Random.Range(-screenSpawn.x, screenSpawn.x), screenSpawn.y);
            Instantiate(enemy, spawnPos, Quaternion.Euler(0f, 0f, 180f));
            spawnTime = Time.time + .5f;
        }

        if (scoreNumber == 300 && bossReady)
        {
            Invoke(nameof(bossSpawn), 2f);
            bossReady = false;
        }
    }

    void bossSpawn()
    {
        Instantiate(boss, new Vector2(0, screenSpawn.y), Quaternion.Euler(0f, 0f, 180f));
    }

    void ScoreCount(int score)
    {
        scoreNumber += score;
    }
}
