using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System;

public enum EnemyAttackType { Melee, Range };
public class EnemyEvents
{
    public UnityEvent PlayerEntersVisionRange = new UnityEvent();
    public UnityEvent PlayerLeavesVisionRange = new UnityEvent();
    public UnityEvent PlayerEntersAttackRange = new UnityEvent();
    public UnityEvent PlayerLeavesAttackRange = new UnityEvent();
}


public class EnemyController : MonoBehaviour
{
    #region StateManager
    public EnemyStateManager StateManager { get; private set; }
    public EnemyIdleState IdleState { get; private set; }
    public EnemyRoamingState RoamingState { get; private set; }
    public EnemyMovingToTargetState MovingToTargetState { get; private set; }
    public EnemyAttackingState AttackingState { get; private set; }

    #endregion

    [SerializeField] private EnemyState.State currentState;
    
    //attacking vars
    private int attackDamage;
    private float attackSpeed; // attacks per second
    private float attackRange;
    private EnemyAttackType attackType;
    
    //defensive vars
    private int armor;
    private int magicResist;

    //utility vars
    public Slider enemyHealthBarSlider;
    [SerializeField] private float health;
    private int mana;
    private float movementSpeed;
    private float visionRange;

    [SerializeField] private GameObject target; // should be the Player in most cases, could be something that the Player summoned
    [SerializeField] private float distanceToTarget;


    public EnemyEvents EnemyEvents; // Events for this gameObject
    private float timeForNextAttack = 0;
    RoamingMovementVars roamingMovementVars;

    private bool isDead;


#region GETTERS AND SETTERS
    public EnemyState.State CurrentState { get => currentState; set => currentState = value; }
    public int AttackDamage { get => this.attackDamage; set {this.attackDamage = value;}}
    public float AttackSpeed { get => this.attackSpeed; set {this.attackSpeed = value;}}
    public float AttackRange { get => this.attackRange; set {this.attackRange = value;}}
    public EnemyAttackType AttackType { get => this.attackType; set {this.attackType = value;}}
    public int Armor { get => this.armor; set {this.armor = value;}}
    public int MagicResist { get => this.magicResist; set {this.magicResist = value;}}
    public float Health { get => this.health; set {this.health = value;}}
    public int Mana { get => this.mana; set {this.mana = value;}}
    public float MovementSpeed { get => this.movementSpeed; set {this.movementSpeed = value;}}
    public float VisionRange { get => visionRange; set => visionRange = value;}
    public GameObject Target { get => target; set => target = value;}
    public float DistanceToTarget { get => distanceToTarget; set => distanceToTarget = value;}

#endregion


    #region Enemy Events
    [NonSerialized] public UnityEvent<float> EnemyTakeDamage = new UnityEvent<float>();
    #endregion

    private void Awake() 
    {
        Initialize();
        InitializeStateManager();
    }

    private void Start() 
    {
        InitializeControllerVars();
        InitializeRoamingVars();
        StateManager.Initialize(IdleState);

    // Add listeners to EnemyEvents ==================================================
        EnemyEvents.PlayerEntersVisionRange.AddListener(OnPlayerEntersVisionRange);
        EnemyEvents.PlayerLeavesVisionRange.AddListener(OnPlayerLeavesVisionRange);
        EnemyEvents.PlayerEntersAttackRange.AddListener(OnPlayerEntersAttackRange);
        EnemyEvents.PlayerLeavesAttackRange.AddListener(OnPlayerLeavesAttackRange);
    // ===============================================================================

    }

    private void Update()
    {
        StateManager.CurrentState.LogicalUpdates(); 
    }

    private void FixedUpdate() 
    {
        StateManager.CurrentState.PhysicalUpdates();    
    }

    private void Initialize()
    {
        movementSpeed = 0.0f;
        visionRange = 0.0f;
        target = null;
        distanceToTarget = 0.0f;

        EnemyEvents = new EnemyEvents();
    }
    private void InitializeStateManager()
    {
        StateManager = new EnemyStateManager();
        IdleState = new EnemyIdleState(this, StateManager, global::EnemyState.State.Idle);
        RoamingState = new EnemyRoamingState(this, StateManager, global::EnemyState.State.Roaming);
        MovingToTargetState = new EnemyMovingToTargetState(this, StateManager, global::EnemyState.State.MovingToTarget);
        AttackingState = new EnemyAttackingState(this, StateManager, global::EnemyState.State.Attacking);
    }
    public virtual void InitializeControllerVars() 
    {
        enemyHealthBarSlider.value = enemyHealthBarSlider.maxValue = Health;
    }
    public virtual void InitializeRoamingVars() // BASE Initialize of roamingMovementVars struct
    {
        roamingMovementVars = new RoamingMovementVars()
        {
            arrived = true,
            finishedIdle = false,
            roamingMovementSpeed = movementSpeed/3,

            isIdle = roamingMovementVars.ShouldIdleOrNot(),
            idleStartTime = 0f,
            idleDuration = roamingMovementVars.GetIdleDuration(),
        };
    }

    public void Idle()
    {
        if (roamingMovementVars.finishedIdle)
        { 
            StateManager.ChangeState(RoamingState);
        }
        else
        {
            if (Time.time - roamingMovementVars.idleStartTime >= roamingMovementVars.idleDuration)
            {
                roamingMovementVars.finishedIdle = true;
            }
        }
    }

    // Think about making RoamAround and Idle functions Coroutine
    public void RoamAround()
    {
        if (roamingMovementVars.arrived)
        {
            roamingMovementVars.destinationPoint = GenerateRoamingPointFromGivenPoint(roamingMovementVars.roamStartPoint, 2, 2);

            Debugger.Log(this, "Next destination point -> " + roamingMovementVars.destinationPoint); // printing the next roaming point

            roamingMovementVars.arrived = false;
        }
        else
        {
            MoveForwardpoint(roamingMovementVars.destinationPoint, roamingMovementVars.roamingMovementSpeed);
            if (Vector3.Distance(transform.position, roamingMovementVars.destinationPoint) <= 0.1f)
            {   
                roamingMovementVars.arrived = true;

                // REALLY BAD CODE ... Make it better if possible
                if (roamingMovementVars.ShouldIdleOrNot())
                {
                    roamingMovementVars.idleStartTime = Time.time;
                    roamingMovementVars.idleDuration = roamingMovementVars.GetIdleDuration();
                    roamingMovementVars.finishedIdle = false;
                    
                    StateManager.ChangeState(IdleState);
                }
            }
        }
    }
    public void MoveTowardsTarget()
    {
        if (Target == null)
        {
            Debugger.Log(this, "has NO Target !!!");
        }
        else
        {
            MoveForwardpoint(Target.transform.position, movementSpeed);
        }
    }
    private void MoveForwardpoint(Vector3 point, float movementSpeed)
    {
        // Run animation here :)

        // gameObject.transform.LookAt(point); // in order to look at the point

        // changing the position of the enemy unit each frame towards the targeted point
        gameObject.transform.position += GetDirectionToPoint(point).normalized * Time.deltaTime * movementSpeed;

        timeForNextAttack = Time.time + (1 / AttackSpeed); // in order not to attack instantly when target is reached
    }
    public void AttackTarget()
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

    private Vector3 GenerateRandomPointInRange(float minX, float maxX, float minZ, float maxZ)
    {
        return new Vector3(UnityEngine.Random.Range(minX, maxX), //x
                    gameObject.transform.position.y, // y
                    UnityEngine.Random.Range(minZ, maxZ)); //z
    }
    private Vector3 GenerateRoamingPointFromGivenPoint(Vector3 point, float offsetX, float offsetZ)
    {
        return GenerateRandomPointInRange(point.x - offsetX, point.x + offsetX, 
                                            point.z - offsetZ, point.z + offsetZ);
    }
    public Vector3 GetDirectionToPoint(Vector3 point)
    {
        Vector3 headingTowardTarget = new Vector3(point.x - transform.position.x, 0, point.z - transform.position.z);
        return headingTowardTarget / distanceToTarget;
    }

    private void OnPlayerEntersVisionRange()
    {
        Debugger.Log(this, "Player Enters Vision Range! ");

        Target = Player.singleton.gameObject;

        StateManager.ChangeState(MovingToTargetState);
    }
    private void OnPlayerLeavesVisionRange()
    {
        Debugger.Log(this, "Player Left Vision Range! ");

        Target = null;
        roamingMovementVars.roamStartPoint = gameObject.transform.position;
        roamingMovementVars.arrived = true; // in order always to enter in MoveAround function arrived, so it will calculate new direction

        if (roamingMovementVars.ShouldIdleOrNot())
        {
            roamingMovementVars.idleStartTime = Time.time;
            roamingMovementVars.idleDuration = roamingMovementVars.GetIdleDuration();
            StateManager.ChangeState(IdleState);
        }
        else
        {
            StateManager.ChangeState(RoamingState);
        }
    }
    private void OnPlayerEntersAttackRange()
    {
        Debugger.Log(this, "Player Enters Attack Range! ");

        StateManager.ChangeState(AttackingState);
    }
    private void OnPlayerLeavesAttackRange()
    {
        Debugger.Log(this, "Player Left Attack Range! ");
        
        // To check if still has a targeted Player
        if (Target)
        {
            StateManager.ChangeState(MovingToTargetState);
        }
        else
        {
            StateManager.ChangeState(IdleState);
        }
    }

    protected void OnDead()
    {
        // Dead animation ... etc
        Debug.Log("Enemy is Dead !");
        isDead = true;
        Destroy(gameObject);
    }
    public void TakeDamage(float damage)
    {
        // Take damage animation

        FloatingTextManager.singleton.Show("- " + damage, 20, Color.yellow, transform.position, Vector3.up * 50, 2.0f);

        Health -= damage;
        enemyHealthBarSlider.value -= damage;

        if (Health <= 0)
        {
            OnDead();
        }
    }
}
