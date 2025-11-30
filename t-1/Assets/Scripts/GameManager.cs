using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Player Settings")]
    public int maxPlayerHealth = 100;
    public int currentPlayerHealth;
    public GameOverScript gameOver;

    private void Awake()
    {
        
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        currentPlayerHealth = maxPlayerHealth;
    }

    public void TakePlayerDamage(int damage)
    {
        currentPlayerHealth -= damage;
        currentPlayerHealth = Mathf.Clamp(currentPlayerHealth, 0, maxPlayerHealth);

        Debug.Log($"Player HP: {currentPlayerHealth}");

        // Update health bar
        UIManager.Instance?.UpdateHealthBar(currentPlayerHealth, maxPlayerHealth);

        if (currentPlayerHealth <= 0)
        {
            PlayerDied();
        }
    }

    private void PlayerDied()
    {
        Debug.Log("Player died! Game Over!");
        gameOver.Setup();
    }

    public void HealPlayer(int amount)
    {
        currentPlayerHealth += amount;
        currentPlayerHealth = Mathf.Clamp(currentPlayerHealth, 0, maxPlayerHealth);
        UIManager.Instance?.UpdateHealthBar(currentPlayerHealth, maxPlayerHealth);
    }
}
