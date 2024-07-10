using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform[] spawnPoints;

    public float spawnInterval = 3f; // Interval between spawns
    private float spawnTimer;        // Timer to count when to spawn next enemy

    void Start()
    {
        spawnTimer = spawnInterval;
    }

    void Update()
    {
        // Count down the timer
        spawnTimer -= Time.deltaTime;

        // If the timer has expired, spawn an enemy and reset the timer
        if (spawnTimer <= 0f)
        {
            SpawnEnemy();
            spawnTimer = spawnInterval;
        }
    }

    void SpawnEnemy()
    {
        // Choose a random spawn point
        int randomIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[randomIndex];

        // Instantiate the enemy at the chosen spawn point
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}