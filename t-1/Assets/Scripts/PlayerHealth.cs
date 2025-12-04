using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;
    public Slider healthBar; 

    
    public event System.Action OnPlayerDied;

    void Start()
    {
        currentHealth = maxHealth;
        if (healthBar != null)
        {
            healthBar.value = currentHealth / maxHealth;
        }

        Debug.Log("PlayerHealth Start: CurrentHealth = " + currentHealth);
    }

    public void TakeDamage(float damage)
    {
        Debug.Log("TakeDamage called with damage: " + damage);

        currentHealth -= damage;
        if (currentHealth < 0) currentHealth = 0;

        Debug.Log("CurrentHealth after damage: " + currentHealth);

        if (healthBar != null)
        {
            healthBar.value = currentHealth / maxHealth;
            Debug.Log("HealthBar updated to: " + healthBar.value);
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Player died!");
        
        OnPlayerDied?.Invoke();
    }
}
