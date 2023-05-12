using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject objectToSpawn;
    public int numberOfObjects;
    public float spawnRadius;
    public float minDistanceBetweenObjects; // Minimum distance between objects

    private List<Vector3> existingPositions = new List<Vector3>();

    void Start()
    {
        SpawnObjects();
    }

    void SpawnObjects()
    {
        for (int i = 0; i < numberOfObjects; i++)
        {
            Vector3 spawnPosition = Vector3.zero;
            bool positionValid = false;

            // Try to find a valid position
            while (!positionValid)
            {
                Vector2 randomPos = Random.insideUnitCircle * spawnRadius;
                spawnPosition = new Vector3(randomPos.x, 0, randomPos.y) + transform.position;

                if (IsPositionValid(spawnPosition))
                {
                    positionValid = true;
                }
            }

            // Instantiate (spawn) the object at the random position
            Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
            existingPositions.Add(spawnPosition);
        }
    }

    bool IsPositionValid(Vector3 position)
    {
        foreach (Vector3 existingPosition in existingPositions)
        {
            if (Vector3.Distance(position, existingPosition) < minDistanceBetweenObjects)
            {
                return false; // This position is too close to an existing object
            }
        }

        return true; // This position is far enough from existing objects
    }
}
