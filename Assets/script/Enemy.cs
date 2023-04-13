using UnityEngine;

[RequireComponent(typeof(EnemyAfter))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private int maxHitPoint = 5;
    [SerializeField] private int healthRamp = 1;
    
    private EnemyAfter enemy;
    private int currentHP;
    private void Start()
    {
        enemy = GetComponent<EnemyAfter>();
    }
    private void OnEnable()
    {
        currentHP = maxHitPoint;
    }
    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    private void ProcessHit()
    {
        currentHP--;
        if ( currentHP <= 0)
        {
            enemy.RewardGold();
            maxHitPoint += healthRamp;
            gameObject.SetActive(false);
        }
    }
}
