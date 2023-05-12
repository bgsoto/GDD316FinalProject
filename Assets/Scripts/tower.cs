using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tower : MonoBehaviour
{
    public GameObject missilePrefab;
    public Transform missileSpawnPoint;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("collision");
        if (other.CompareTag("Enemy"))
        {
            SpawnMissile();
        }
    }

    private void SpawnMissile()
    {
        Instantiate(missilePrefab, missileSpawnPoint.position, missileSpawnPoint.rotation);
    }
}

