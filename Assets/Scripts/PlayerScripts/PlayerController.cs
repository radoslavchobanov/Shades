using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;
using System;

public class PlayerController : MonoBehaviour
{
    #region Player Stats
    [SerializeField] private PlayerStats playerStats;
    #endregion

    #region StateManager
    public PlayerStateManager StateManager { get; private set; }

    public PlayerIdleState IdleState { get; private set; }
    public PlayerCombatIdleState CombatIdleState { get; private set; }
    public PlayerNoCombatIdleState NoCombatIdleState { get; private set; }

    public PlayerMoveState MoveState { get; private set; }
    public PlayerCombatRunState CombatRunState { get; private set; }
    public PlayerCombatWalkState CombatWalkState { get; private set; }
    public PlayerNoCombatRunState NoCombatRunState { get; private set; }
    public PlayerNoCombatWalkState NoCombatWalkState { get; private set; }

    public PlayerAttackState AttackState { get; private set; }
    public PlayerDashState DashState { get; private set; }
    public PlayerDeadState DeadState { get; private set; }
    #endregion


    #region PlayerInput
    public PlayerInputHandler InputHandler { get; private set; }
    #endregion


    #region Controller variables
    public string Weapon = "gun";
    public bool CombatStance = true;

    [SerializeField] private PlayerState.State currentState;
    private Animator animator;
    public bool isDead;
    #endregion


    #region GETTERS AND SETTERS
    public PlayerStats PlayerStats { get => playerStats; set => playerStats = value; }
    public PlayerState.State CurrentState { get => currentState; set => currentState = value; }
    public Animator Animator { get => animator; set => animator = value; }

    public float AttackSpeed { get => playerStats.attackSpeed; set => playerStats.attackSpeed = value; }
    public float RunSpeed { get => playerStats.runSpeed; set => playerStats.runSpeed = value; }
    public float Walkspeed { get => playerStats.walkSpeed; set => playerStats.walkSpeed = value; }
    public Health Health { get => playerStats.health; }
    public Stamina Stamina { get => playerStats.stamina; }
    public Energy Energy { get => playerStats.energy; }

    #endregion


    #region References
    [NonSerialized] public LaserSightAim laserSightAimComponent; // to enabled AimAtPointer.cs script

    #endregion

    #region Shooting vars
    public GameObject ShootingStartPoint; // the point from where the bullet fires
    public GameObject BulletPrefab; // prefab of the bullet. no shit.

    #endregion


    #region Player Events
    [NonSerialized] public UnityEvent<float> PlayerTakeDamage = new UnityEvent<float>();
    #endregion


    protected void OnControllerAwake()
    {
        StateManager = new PlayerStateManager();

        IdleState = new PlayerIdleState(this, StateManager, global::PlayerState.State.Idle);
        CombatIdleState = new PlayerCombatIdleState(this, StateManager, global::PlayerState.State.Idle);
        NoCombatIdleState = new PlayerNoCombatIdleState(this, StateManager, global::PlayerState.State.Idle);

        MoveState = new PlayerMoveState(this, StateManager, global::PlayerState.State.Move);
        CombatRunState = new PlayerCombatRunState(this, StateManager, global::PlayerState.State.Run);
        CombatWalkState = new PlayerCombatWalkState(this, StateManager, global::PlayerState.State.Walk);
        NoCombatRunState = new PlayerNoCombatRunState(this, StateManager, global::PlayerState.State.Run);
        NoCombatWalkState = new PlayerNoCombatWalkState(this, StateManager, global::PlayerState.State.Walk);

        AttackState = new PlayerAttackState(this, StateManager, global::PlayerState.State.Attack);
        DashState = new PlayerDashState(this, StateManager, global::PlayerState.State.Dash);
        DeadState = new PlayerDeadState(this, StateManager, global::PlayerState.State.Dead);

        InitializeController();
    }
    protected void OnControllerStart()
    {
        InputHandler = GetComponent<PlayerInputHandler>();
        Animator = GetComponentInChildren<Animator>();
        laserSightAimComponent = GetComponent<LaserSightAim>();

        StateManager.Initialize(IdleState);
    }

    protected void OnControllerUpdate()
    {
        StateManager.CurrentState.LogicalUpdates();
    }
    protected void OnControllerFixedUpdate()
    {
        StateManager.CurrentState.PhysicalUpdates();
    }
    protected void OnControllerLateUpdate()
    {
        StateManager.CurrentState.AnimationUpdates();
        
        RegenerationUpdates();
    }

    public virtual void InitializeController()
    {
        playerStats.InitializeStats();
        isDead = false;
        playerStats.timeForNextAttack = 0;
    }
    private void RegenerationUpdates() // regenerates every second
    {
        Health.UpdateRegenerate();
        Energy.UpdateRegenerate();
    }

    public void TakeDamage(float damage)
    {
        // Take damage animation
        PlayerTakeDamage.Invoke(damage);

        FloatingTextManager.singleton.Show("- " + damage, 20, Color.red, transform.position, Vector3.up * 50, 2.0f);

        Health.current -= damage;

        if (Health.current <= 0)
        {
            OnDead();
        }
    }
    private void OnDead()
    {
        isDead = true;
        StateManager.ChangeState(DeadState);
    }

    public void Shoot()
    {
        playerStats.timeForNextAttack = Time.time + (1 / AttackSpeed);
        Instantiate(BulletPrefab, ShootingStartPoint.transform.position, ShootingStartPoint.transform.rotation);
    }

    public void Move(Vector3 direction, float speed)
    {
        if (direction.magnitude > 0)
        {
            direction.Normalize();
            direction *= speed * Time.deltaTime;
            gameObject.transform.Translate(direction, Space.World);
        }
    }
    public bool CanAttack()
    {
        return (Time.time >= playerStats.timeForNextAttack);
    }
    public bool CanDash()
    {
        return (Time.time >= playerStats.timeForNextDash);
    }
}
