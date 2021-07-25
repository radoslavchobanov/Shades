using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum EnemyState {Idle, MovingToTarget, Attacking};
public enum EnemyAttackType { Melee, Range };
public class EnemyEvents
{
    public UnityEvent PlayerEntersVisionRange = new UnityEvent();
    public UnityEvent PlayerLeavesVisionRange = new UnityEvent();
    public UnityEvent PlayerEntersAttackRange = new UnityEvent();
    public UnityEvent PlayerLeavesAttackRange = new UnityEvent();
}
// reused code ... better RandomMovement system is a must !
public struct RandomMovementVars
{
    public float latestDirectionChangeTime;
    public float directionChangeTime;
    public float characterVelocity;
    public Vector2 movementDirection;
    public Vector2 movementPerSecond;
}


public class EnemyController : MonoBehaviour
{
    [SerializeField] private EnemyState state;
    
    //attacking vars
    private int attackDamage;
    private float attackSpeed; // attacks per second
    private float attackRange;
    private EnemyAttackType attackType;
    
    //defensive vars
    private int armor;
    private int magicResist;

    //utility vars
    private int health;
    private int mana;
    private float movementSpeed;
    private float visionRange;

    [SerializeField] private GameObject target; // should be the Player in most cases, could be something that the Player summoned
    [SerializeField] private float distanceToTarget;


    public EnemyEvents EnemyEvents; // Events for this gameObject
    private float timeForNextAttack = 0;
    RandomMovementVars randomMovementVars;


#region GETTERS AND SETTERS
    public EnemyState State { get => state; set => state = value;}
    public int AttackDamage { get => this.attackDamage; set {this.attackDamage = value;}}
    public float AttackSpeed { get => this.attackSpeed; set {this.attackSpeed = value;}}
    public float AttackRange { get => this.attackRange; set {this.attackRange = value;}}
    public EnemyAttackType AttackType { get => this.attackType; set {this.attackType = value;}}
    public int Armor { get => this.armor; set {this.armor = value;}}
    public int MagicResist { get => this.magicResist; set {this.magicResist = value;}}
    public int Health { get => this.health; set {this.health = value;}}
    public int Mana { get => this.mana; set {this.mana = value;}}
    public float MovementSpeed { get => this.movementSpeed; set {this.movementSpeed = value;}}
    public float VisionRange { get => visionRange; set => visionRange = value;}
    public GameObject Target { get => target; set => target = value;}
    public float DistanceToTarget { get => distanceToTarget; set => distanceToTarget = value;}

#endregion

    private void Awake() 
    {
        Initialize();
    }

    private void Start() 
    {
        InitializeControllerVars();

    // Add listeners to EnemyEvents ==================================================
        EnemyEvents.PlayerEntersVisionRange.AddListener(OnPlayerEntersVisionRange);
        EnemyEvents.PlayerLeavesVisionRange.AddListener(OnPlayerLeavesVisionRange);
        EnemyEvents.PlayerEntersAttackRange.AddListener(OnPlayerEntersAttackRange);
        EnemyEvents.PlayerLeavesAttackRange.AddListener(OnPlayerLeavesAttackRange);
    // ===============================================================================

    // Initialize RandomMovementVars struct ==========================================
        randomMovementVars = new RandomMovementVars()
        {
            directionChangeTime = 3f,
            latestDirectionChangeTime = 0f,
        };
        calcuateNewMovementVector();
    // ===============================================================================
    }

    private void Update()
    {
        switch (State)
        {
            case EnemyState.Idle: 
                MoveAround();
                break;

            case EnemyState.MovingToTarget:
                MoveTowardsTarget();
                break;

            case EnemyState.Attacking:
                AttackTarget();
                break;
        }
    }

    private void Initialize()
    {
        movementSpeed = 0.0f;
        visionRange = 0.0f;
        target = null;
        distanceToTarget = 0.0f;

        EnemyEvents = new EnemyEvents();
    }

    public virtual void InitializeControllerVars() {}

    private void MoveAround()
    {
        //if the changeTime was reached, calculate a new movement vector
        if (Time.time - randomMovementVars.latestDirectionChangeTime > randomMovementVars.directionChangeTime)
        {
            randomMovementVars.latestDirectionChangeTime = Time.time;
            calcuateNewMovementVector();
        }
        
        //move enemy: 
        gameObject.transform.position = new Vector3(gameObject.transform.position.x + (randomMovementVars.movementPerSecond.x * Time.deltaTime),
                                        gameObject.transform.position.y, 
                                        gameObject.transform.position.z + (randomMovementVars.movementPerSecond.y * Time.deltaTime));
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
            MoveForward();
        }
    }
    private void MoveForward()
    {
        // Run animation here :)

        // changing the position of the enemy unit each frame towards the targeted Player
        gameObject.transform.position += GetDirectionToTarget() * Time.deltaTime * movementSpeed;

        timeForNextAttack = Time.time + (1 / AttackSpeed); // in order not to attack instantly when target is reached
    }
    private void AttackTarget()
    {
        // Play attack animation here

        // For now only attacks the Player
        if (!Player.singleton.isDead && Time.time > timeForNextAttack)
        {
            // this is messy !!! - function called AttackTarget but it directly attacks the main Player
            Player.singleton.TakeDamage(this.AttackDamage);
            timeForNextAttack = Time.time + (1 / AttackSpeed);
        }
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
    private void calcuateNewMovementVector()
    {
        //create a random direction vector with the magnitude of 1, later multiply it with the velocity of the enemy
        randomMovementVars.movementDirection = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f)).normalized;
        randomMovementVars.movementPerSecond = randomMovementVars.movementDirection * movementSpeed/3;
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
