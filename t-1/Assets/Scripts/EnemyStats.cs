using UnityEngine;
using System;

[CreateAssetMenu(fileName = "EnemyStats", menuName = "Stats/Enemy Stats")]
public class EnemyStats : ScriptableObject
{
    public string enemyName;
    public int maxHealth = 100;
    public float moveSpeed = 3f;
    public int attackDamage = 10;
    public Sprite enemySprite;
    public float spriteScale = 1f;

    
    public event Action<EnemyStats> OnAttackPlayer;

    
    public void NotifyPlayerAttacked()
    {
        OnAttackPlayer?.Invoke(this);
    }
}
