using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    [Header("Enemy Settings")]
    public GameObject enemyPrefab;
    public float spawnInterval = 2f; // Time between spawns

    [Header("Screen Bounds")]// We don't want enemies spawning directly on screen
    public float minX = -8f;
    public float maxX = 8f;
    public float minY = -5f;
    public float maxY = 5f;

    [Header("Spawn Buffers")]//Spawning should be a bit randomized off screen
    public float xBuffer = 5f;  
    public float yBuffer = 2.5f;

    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (true) 
        {
            Vector3 spawnPos = GetOffScreenPosition();
            Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
            yield return new WaitForSeconds(spawnInterval);
            spawnInterval -= 0.01f; // Decrease spawn interval over time to increase difficulty
        }
    }

    Vector3 GetOffScreenPosition() // Returns a random position just outside the screen view so player can't see spawn
    {
        float x, y;
        bool spawnLeftOrRight = Random.value > 0.5f;

        if (spawnLeftOrRight)
        {
          
            x = Random.value > 0.5f ? minX - xBuffer : maxX + xBuffer;
            y = Random.Range(minY - yBuffer, maxY + yBuffer);
        }
        else
        {
        
            x = Random.Range(minX - xBuffer, maxX + xBuffer);
            y = Random.value > 0.5f ? minY - yBuffer : maxY + yBuffer;
        }

        return new Vector3(x, y, 0f);
    }
}
