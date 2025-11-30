using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public EnemyStats stats;  
    private int currentHealth;

    void Start()
    {
        currentHealth = stats.maxHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        Debug.Log($"{stats.enemyName} took {amount} damage! Health: {currentHealth}");

        if (currentHealth <= 0)
            Die();
    }

    void Die()
    {
        Debug.Log($"{stats.enemyName} died!");
        Destroy(gameObject);
    }
}
