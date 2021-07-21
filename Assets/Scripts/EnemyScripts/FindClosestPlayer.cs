using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindClosestPlayer : MonoBehaviour
{
    private EnemyController enemyController; // EnemyController script attached to the enemy ... !!!cannot not have one

    private void Awake()
    {
        enemyController = gameObject.GetComponent<EnemyController>();
    }

    private void Start()
    {
    }

    private void Update() 
    {
        FindClosestPlayer_();
    }
    
    private void FindClosestPlayer_()
    {
        var player = Player.singleton;
        var distance = 0.0f;

        distance = Vector3.Distance(gameObject.transform.position, player.transform.position);

        if (distance < enemyController.VisionRange) // if the target is in the VisionRange
        {
            enemyController.Target = player.gameObject;
            enemyController.transform.LookAt(enemyController.Target.transform);
            enemyController.DistanceToTarget = distance;
            enemyController.State = EnemyState.Moving;
        }

// NOTE: Can be made to Invoke events when target is in VisionRange or not !!!

        else
        {
            enemyController.Target = null;
            enemyController.DistanceToTarget = 0.0f;
            enemyController.State = EnemyState.Idle;
        }
    }
}
