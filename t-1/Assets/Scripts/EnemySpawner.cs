using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public EnemyStats[] enemyTypes;
    public float spawnInterval = 3f;

    void Start()
    {
        // Start spawning immediately when the scene loads
        StartCoroutine(SpawnCoroutine());
    }

    IEnumerator SpawnCoroutine()
    {
        while (true)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnEnemy()
    {
        // Pick a random enemy type
        EnemyStats chosenStats = enemyTypes[Random.Range(0, enemyTypes.Length)];

        // Random X outside screen bounds
        float x = Random.value < 0.5f ? Random.Range(-14f, -9f) : Random.Range(9f, 14f);

        // Random Y outside screen bounds
        float y = Random.value < 0.5f ? Random.Range(-11f, -6f) : Random.Range(6f, 11f);

        Vector3 spawnPos = new Vector3(x, y, 0f);
        GameObject enemy = Instantiate(enemyPrefab, spawnPos, Quaternion.identity);

        // Assign stats
        EnemyHealth health = enemy.GetComponent<EnemyHealth>();
        if (health != null)
            health.stats = chosenStats;

        // Assign speed to follow script
        EnemyFollow follow = enemy.GetComponent<EnemyFollow>();
        if (follow != null)
            follow.speed = chosenStats.moveSpeed;
    }
}
