using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHitPoints = 5;

    [Tooltip("Adds amount to maxHitPoint when enemy dies")]
    [SerializeField] int difficulyRamp = 1;
    int currentHitPoint = 0;
    Enemy enemy;

    void OnEnable()
    {
        currentHitPoint = maxHitPoints;
    }
    void Start()
    {
        enemy = GetComponent<Enemy>(); 

    }

    void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }
    void ProcessHit()
    {
        currentHitPoint--;
        if (currentHitPoint <= 0)
        {
            gameObject.SetActive(false);
            maxHitPoints += difficulyRamp; 
            enemy.RewardGold();
        }
    }

 
}
