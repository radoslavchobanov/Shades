using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState {Idle, MovingToTarget, Attacking};

public class EnemyController : MonoBehaviour
{
    [SerializeField] private EnemyState state;

    [SerializeField] private float movementSpeed;
    [SerializeField] private float attackRange;
    [SerializeField] private float visionRange;

    [SerializeField] private GameObject target; // should be the Player in most cases, could be something that the Player summoned
    [SerializeField] private float distanceToTarget;

    public EnemyState State { get => state; set => state = value;}
    public float MovementSpeed { get => movementSpeed; set => movementSpeed = value;}
    public float AttackRange { get => attackRange; set => attackRange = value;}
    public float VisionRange { get => visionRange; set => visionRange = value;}
    public GameObject Target { get => target; set => target = value;}
    public float DistanceToTarget { get => distanceToTarget; set => distanceToTarget = value;}

    private void Awake() 
    {
        Initialize();
    }

    private void Start() 
    {
        InitializeControllerVars();

        EnemyEvents.PlayerEntersVisionRange.AddListener(OnPlayerEntersVisionRange);
        EnemyEvents.PlayerLeavesVisionRange.AddListener(OnPlayerLeavesVisionRange);
        EnemyEvents.PlayerEntersAttackRange.AddListener(OnPlayerEntersAttackRange);
        EnemyEvents.PlayerLeavesAttackRange.AddListener(OnPlayerLeavesAttackRange);
    }

    private void Update()
    {
        switch (State)
        {
            case EnemyState.Idle: 
                break;

            case EnemyState.MovingToTarget:
                MoveTowardsTarget();
                break;

            case EnemyState.Attacking:
                break;
        }
    }

    private void Initialize()
    {
        movementSpeed = 0.0f;
        visionRange = 0.0f;
        target = null;
        distanceToTarget = 0.0f;
    }

    public virtual void InitializeControllerVars()
    {
        MovementSpeed = 2f;
        VisionRange = 7f;
        AttackRange = 2f;
    }

    private void MoveTowardsTarget()
    {
        if (Target == null)
        {
            Debug.Log(this.gameObject.name + "has NO Target !!!");
        }
        else
        {
            FaceTarget();
            Move();
        }
    }
    private void Move()
    {
        // Run animation here :)

        // changing the position of the enemy unit each frame towards the targeted Player
        gameObject.transform.position += GetDirectionToTarget() * Time.deltaTime * movementSpeed;
    }

    private void FaceTarget()
    {
        transform.LookAt(Target.transform);
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

    private void OnPlayerEntersVisionRange()
    {
        Debug.Log("Player Enters Vision Range! ");

        Target = Player.singleton.gameObject;

        State = EnemyState.MovingToTarget;
    }
    private void OnPlayerLeavesVisionRange()
    {
        Debug.Log("Player Left Vision Range! ");

        Target = null;

        State = EnemyState.Idle;
    }
    private void OnPlayerEntersAttackRange()
    {
        Debug.Log("Player Enters Attack Range! ");

        State = EnemyState.Attacking;
    }
    private void OnPlayerLeavesAttackRange()
    {
        Debug.Log("Player Left Attack Range! ");
        
        // To check if still has a targeted Player
        if (Target)
        {
            State = EnemyState.MovingToTarget;
        }
        else
        {
            State = EnemyState.Idle;
        }
    }
}
