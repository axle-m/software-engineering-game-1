using UnityEngine;

[CreateAssetMenu(fileName = "EnemyStats", menuName = "Stats/Enemy Stats")]
public class EnemyStats : ScriptableObject
{
    public string enemyName;
    public int maxHealth = 100;
    public float moveSpeed = 3f;
    public int attackDamage = 10;
}
