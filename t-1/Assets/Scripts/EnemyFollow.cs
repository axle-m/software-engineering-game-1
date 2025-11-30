using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public Transform player;
    public float speed = 3f;

    [Header("Optional Scaling")]
    public float sizeMultiplier = 1f;

    private EnemyHealth healthScript;
    private SpriteRenderer sr;

    void Start()
    {
        
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

      
        healthScript = GetComponent<EnemyHealth>();
        if (healthScript != null && healthScript.stats != null)
        {
            speed = healthScript.stats.moveSpeed; 
        }

        
        sr = GetComponent<SpriteRenderer>();
        if (sr == null)
        {
            Debug.LogWarning("No SpriteRenderer found! Flipping will not work.");
        }

        
        transform.localScale = Vector3.one * sizeMultiplier;
    }

    void Update()
    {
        Follow();
        FacePlayer();
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

    void FacePlayer()
    {
        if (sr == null || player == null) return;

        
        if (player.position.x > transform.position.x)
            sr.flipX = true;
        else
            sr.flipX = false;
    }

    
    public void SetSize(float scalar)
    {
        sizeMultiplier = scalar;
        transform.localScale = Vector3.one * sizeMultiplier;
    }
}
