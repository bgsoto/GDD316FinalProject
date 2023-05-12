using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// This is needed to load a new scene

public class goal2 : MonoBehaviour
{
    public int enemyKillCount = 0; // This is the counter for the enemies killed
    public int enemiesToKill = 20; // This is the number of enemies to kill to go to the next level

    // Update is called once per frame
    void Update()
    {
        // Here we check if the kill count has reached the required number of kills
        if (enemyKillCount >= enemiesToKill)
        {
            // If it has, then we load the next level
            LoadNextLevel();
        }
    }

    public void EnemyKilled()
    {
        // This function is called whenever an enemy is killed
        enemyKillCount++;
    }

    void LoadNextLevel()
    {
      

      

        // Then we load the next level
        SceneManager.LoadScene("level2");
    }
}

