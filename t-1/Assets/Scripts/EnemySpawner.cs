using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public EnemyStats[] enemyTypes;
    public float spawnInterval = 3f;
    public Transform player;

    void Start()
    {
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
        EnemyStats chosenStats = enemyTypes[Random.Range(0, enemyTypes.Length)];

        float x = Random.value < 0.5f ? Random.Range(-14f, -9f) : Random.Range(9f, 14f);
        float y = Random.value < 0.5f ? Random.Range(-11f, -6f) : Random.Range(6f, 11f);
        Vector3 spawnPos = new Vector3(x, y, 0f);

        GameObject enemy = Instantiate(enemyPrefab, spawnPos, Quaternion.identity);

        EnemyHealth health = enemy.GetComponent<EnemyHealth>();
        if (health != null)
            health.stats = chosenStats;

        EnemyFollow follow = enemy.GetComponent<EnemyFollow>();
        if (follow != null)
        {
            follow.speed = chosenStats.moveSpeed;
            follow.player = player;
            follow.SetSize(1f);
        }
        EnemyAttack attack = enemy.GetComponent<EnemyAttack>();
        if (attack != null)
            attack.enemyStats = chosenStats; 


        SpriteRenderer sr = enemy.GetComponent<SpriteRenderer>();
        if (sr != null && chosenStats.enemySprite != null)
            sr.sprite = chosenStats.enemySprite;
    }
}
