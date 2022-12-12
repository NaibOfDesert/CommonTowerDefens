using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHitPoints = 5;
    [SerializeField] int currentHitPoint = 0;
    Enemy enemy;

    void Start()
    {
        enemy = GetComponent<Enemy>(); 

    }

    void OnEnable()
    {
        currentHitPoint = maxHitPoints;
    }

    void ProcessHit()
    {
        currentHitPoint--;
        if (currentHitPoint <= 0)
        {
            gameObject.SetActive(false);
            enemy.RewardGold();
        }
    }

    void OnParticleCollision(GameObject other)
    {
        ProcessHit(); 
    }
}
