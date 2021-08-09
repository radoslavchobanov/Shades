using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindClosestPlayer : MonoBehaviour
{
    private EnemyController enemyController; // EnemyController script attached to the enemy ... !!! SHOULD ALWAYS HAVE ONE
    private float distanceToPlayer;

    private void Awake()
    {
        enemyController = gameObject.GetComponent<EnemyController>();
    }

    private void Start()
    {
        distanceToPlayer = 0.0f;
    }

    private void Update() 
    {
        FindClosestPlayer_();
    }
    private void FindDistanceToPlayer()
    {
        distanceToPlayer = Vector3.Distance(gameObject.transform.position, Player.singleton.transform.position);
    }
    
    private void FindClosestPlayer_()
    {
        FindDistanceToPlayer();
// Vision Range

        // when the Target enters in VisionRange
        if (enemyController.DistanceToTarget > enemyController.VisionRange && distanceToPlayer <= enemyController.VisionRange)
        {
            enemyController.EnemyEvents.PlayerEntersVisionRange.Invoke();
        }
        // when the Target leaves from VisionRange
        else if (enemyController.DistanceToTarget <= enemyController.VisionRange && distanceToPlayer > enemyController.VisionRange)
        {
            enemyController.EnemyEvents.PlayerLeavesVisionRange.Invoke();
        }   
// ============

// AttackRange
        // when the Target enters in AttackRange
        else if (enemyController.DistanceToTarget > enemyController.AttackRange && distanceToPlayer <= enemyController.AttackRange)
        {
            enemyController.EnemyEvents.PlayerEntersAttackRange.Invoke();
        }
        // when the Target leaves from AttackRange
        else if (enemyController.DistanceToTarget <= enemyController.AttackRange && distanceToPlayer > enemyController.AttackRange)
        {
            enemyController.EnemyEvents.PlayerLeavesAttackRange.Invoke();
        } 
// =============

        // updates enemie's distance to the Player
        enemyController.DistanceToTarget = distanceToPlayer;
    }
}
