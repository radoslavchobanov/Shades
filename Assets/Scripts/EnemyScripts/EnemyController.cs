using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState {Idle, Moving, Attacking};

public class EnemyController : MonoBehaviour
{
    [SerializeField] private EnemyState state;

    [SerializeField] private float movementSpeed;
    [SerializeField] private float visionRange;

    [SerializeField] private GameObject target; // should be the Player in most cases, could be something that the Player summoned
    [SerializeField] private float distanceToTarget;

    public EnemyState State { get => state; set => state = value;}
    public float MovementSpeed { get => movementSpeed; set => movementSpeed = value;}
    public float VisionRange { get => visionRange; set => visionRange = value;}
    public GameObject Target { get => target; set => target = value;}
    public float DistanceToTarget { get => distanceToTarget; set => distanceToTarget = value;}

    private void Awake() 
    {
        InitializeVars();
    }

    private void Start() 
    {
        MovementSpeed = 2f;
        VisionRange = 7f;
    }

    private void Update() 
    {
        switch (State)
        {
            case EnemyState.Idle: 
                break;

            case EnemyState.Moving:
                MoveTowardsTarget();
                break;

            case EnemyState.Attacking:
                break;
        }
    }

    private void InitializeVars()
    {
        movementSpeed = 0.0f;
        visionRange = 0.0f;
        target = null;
        distanceToTarget = 0.0f;
    }

    private void MoveTowardsTarget()
    {
        gameObject.transform.position += GetDirectionToTarget() * Time.deltaTime * movementSpeed;
    }
    
    public Vector3 GetDirectionToTarget()
    {
        float targetX = Target.transform.position.x;
        float targetZ = Target.transform.position.z;

        float enemyX = gameObject.transform.position.x;
        float enemyZ = gameObject.transform.position.z;

        Vector3 headingTowardTarget = new Vector3(targetX - enemyX, 0, targetZ - enemyZ);
        return headingTowardTarget / distanceToTarget;
    }
}
