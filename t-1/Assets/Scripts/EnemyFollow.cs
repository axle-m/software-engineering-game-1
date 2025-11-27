using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public Transform player;
    public float speed = 3f;

    private EnemyHealth healthScript;

    void Start()
    {
        // Automatically find the player if not assigned
        if (player == null)
        {
            GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
            if (playerObj != null)
            {
                player = playerObj.transform;
            }
            else
            {
                Debug.LogError("Player not found! Make sure it has the 'Player' tag.");
            }
        }

        // Get EnemyHealth component to read stats
        healthScript = GetComponent<EnemyHealth>();
        if (healthScript != null && healthScript.stats != null)
        {
            speed = healthScript.stats.moveSpeed; // assign speed from ScriptableObject
        }
    }

    void Update()
    {
        Follow();
    }

    void Follow()
    {
        if (player == null) return;

        transform.position = Vector2.MoveTowards(
            transform.position,
            player.position,
            speed * Time.deltaTime
        );
    }
}
