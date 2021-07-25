﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum EnemyState {Idle, Roaming, MovingToTarget, Attacking};
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
    RoamingMovementVars roamingMovementVars;


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
        InitializeRoamingVars();

    // Add listeners to EnemyEvents ==================================================
        EnemyEvents.PlayerEntersVisionRange.AddListener(OnPlayerEntersVisionRange);
        EnemyEvents.PlayerLeavesVisionRange.AddListener(OnPlayerLeavesVisionRange);
        EnemyEvents.PlayerEntersAttackRange.AddListener(OnPlayerEntersAttackRange);
        EnemyEvents.PlayerLeavesAttackRange.AddListener(OnPlayerLeavesAttackRange);
    // ===============================================================================

    }

    private void Update()
    {
        switch (State)
        {
            case EnemyState.Idle: 
                Idle();
                break;

            case EnemyState.Roaming:
                RoamAround();
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

    private void Idle()
    {
        // Idle animation
        if (roamingMovementVars.finishedIdle)
        {
            roamingMovementVars.arrived = true; // in order always to enter in MoveAround function arrived, so it will calculate new direction
            roamingMovementVars.roamStartPoint = gameObject.transform.position;
            
            State = EnemyState.Roaming;
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
    private void RoamAround()
    {
        if (roamingMovementVars.arrived)
        {
            roamingMovementVars.destinationPoint = GenerateRoamingPointFromGivenPoint(roamingMovementVars.roamStartPoint, 2, 2);

            Debug.Log(roamingMovementVars.destinationPoint); // printing the next roaming point

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
                    State = EnemyState.Idle;
                }
            }
        }
    }
    private void MoveTowardsTarget()
    {
        if (Target == null)
        {
            Debug.Log(this.gameObject.name + "has NO Target !!!");
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

    private Vector3 GenerateRandomPointInRange(float minX, float maxX, float minZ, float maxZ)
    {
        return new Vector3(Random.Range(minX, maxX), //x
                    gameObject.transform.position.y, // y
                    Random.Range(minZ, maxZ)); //z
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
        Debug.Log("Player Enters Vision Range! ");

        Target = Player.singleton.gameObject;

        State = EnemyState.MovingToTarget;
    }
    private void OnPlayerLeavesVisionRange()
    {
        Debug.Log("Player Left Vision Range! ");

        Target = null;
        roamingMovementVars.roamStartPoint = gameObject.transform.position;

        if (roamingMovementVars.ShouldIdleOrNot())
        {
            roamingMovementVars.idleStartTime = Time.time;
            roamingMovementVars.idleDuration = roamingMovementVars.GetIdleDuration();
            State = EnemyState.Idle;
        }
        else
        {
            State = EnemyState.Roaming;
        }
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
