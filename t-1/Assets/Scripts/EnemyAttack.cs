using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public EnemyStats enemyStats; // Reference to ScriptableObject containing stats

    private void Start()
    {
        
        if (enemyStats == null)
        {
            Debug.LogError($"{gameObject.name} does not have an EnemyStats assigned! Ensure that this is set in the Inspector.");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            
            if (enemyStats != null)
            {
                Debug.Log($"{gameObject.name} hit {collision.name} for {enemyStats.attackDamage} damage!");
                GameManager.Instance.TakePlayerDamage(enemyStats.attackDamage); // Apply damage to the player
            }
            else
            {
                Debug.LogError("EnemyStats is missing! Cannot apply damage.");
            }
        }
    }
}
