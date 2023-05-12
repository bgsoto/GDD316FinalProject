using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class eSpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Prefab of the enemy to spawn
    public float spawnRadius = 10f; // Radius within which enemies are spawned
    public float spawnInterval = 2f; // Time interval between spawns

    private float timer = 0f; // Timer to track spawn intervals

    private void Update()
    {
        // Increment the timer
        timer += Time.deltaTime;

        // Check if it's time to spawn a new enemy
        if (timer >= spawnInterval)
        {
            SpawnEnemy();
            timer = 0f; // Reset the timer
        }
    }

    private void SpawnEnemy()
    {
        // Calculate a random position within the spawn radius
        Vector3 randomPosition = transform.position + Random.insideUnitSphere * spawnRadius;
        randomPosition.y = 0f; // Ensure enemies are spawned at ground level or desired height

        // Spawn the enemy at the random position
        Instantiate(enemyPrefab, randomPosition, Quaternion.identity);
    }
}

