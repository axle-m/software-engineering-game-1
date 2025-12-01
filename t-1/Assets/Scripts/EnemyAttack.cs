using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public EnemyStats enemyStats;

    private void Start()
    {
        if (enemyStats != null && GameManager.Instance != null)
        {
            enemyStats.OnAttackPlayer += GameManager.Instance.HandleEnemyAttack;
        }
    }

    private void OnDestroy()
    {
        if (enemyStats != null && GameManager.Instance != null)
        {
            enemyStats.OnAttackPlayer -= GameManager.Instance.HandleEnemyAttack;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            enemyStats.NotifyPlayerAttacked();
        }
    }
}
