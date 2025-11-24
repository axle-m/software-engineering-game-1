using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public Transform player;
    public float speed = 3f;

    void Update()
    {
       Follow();
    }

    void Follow()
    {
        if(player == null)
        {
            Debug.Log("This doesnt work :(");
        }
        transform.position = Vector2.MoveTowards(
            transform.position,
            player.position,
            speed * Time.deltaTime
        );
    }
}
