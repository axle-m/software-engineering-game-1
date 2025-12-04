using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Player Settings")]
    public int maxPlayerHealth = 100;
    public int currentPlayerHealth;
    public GameOverScript gameOver;

    public PlayerHealth playerHealth;

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

        SceneManager.sceneLoaded += OnSceneLoaded;
        SubscribeToAllEnemies();
        if (playerHealth != null)
    {
        playerHealth.OnPlayerDied += PlayerDied; 
    }
    }
    private void SubscribeToAllEnemies()
    {
        // Find all EnemyAttack scripts in the scene
        EnemyAttack[] allEnemies = FindObjectsOfType<EnemyAttack>();
        foreach (var enemy in allEnemies)
        {
            if (enemy.enemyStats != null)
            {
                enemy.enemyStats.OnAttackPlayer += HandleEnemyAttack;
            }
        }
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        gameOver = FindAnyObjectByType<GameOverScript>(FindObjectsInactive.Include);
        playerHealth = FindAnyObjectByType<PlayerHealth>();

        if(playerHealth != null)
        {
            playerHealth.OnPlayerDied -= PlayerDied;
            
            playerHealth.OnPlayerDied += PlayerDied;
        }

        currentPlayerHealth = maxPlayerHealth;
        SubscribeToAllEnemies();
    }
     public void HandleEnemyAttack(EnemyStats stats)
    {
        Debug.Log($"{stats.enemyName} attacked the player! (Handled in GameManager)");
        if (playerHealth != null)
    {
        playerHealth.TakeDamage(stats.attackDamage);
    }
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
