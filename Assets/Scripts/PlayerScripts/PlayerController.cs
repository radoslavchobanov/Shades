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
    public PlayerRunState RunState { get; private set; }
    public PlayerWalkState WalkState { get; private set; }
    public PlayerAttackState AttackState { get; private set; }
    public PlayerDashState DashState { get; private set; }
    #endregion


    #region PlayerInput
    public PlayerInputHandler InputHandler { get; private set; }
    #endregion


    #region Controller variables
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
    public float Health { get => playerStats.health; set => playerStats.health = value; }
    public Stamina Stamina { get => playerStats.stamina; }

    #endregion


    #region References
    [NonSerialized] public LaserSightAim laserSightAimComponent; // to enabled AimAtPointer.cs script

    #endregion

    #region Shooting vars
    public GameObject ShootingStartPoint; // the point from where the bullet fires
    public GameObject BulletPrefab; // prefab of the bullet. no shit.
    [NonSerialized] public float timeForNextAttack;

    #endregion


    #region Player Events
    [NonSerialized] public UnityEvent<float> PlayerTakeDamage = new UnityEvent<float>();
    #endregion


    protected void OnControllerAwake()
    {
        StateManager = new PlayerStateManager();
        IdleState = new PlayerIdleState(this, StateManager, global::PlayerState.State.Idle);
        RunState = new PlayerRunState(this, StateManager, global::PlayerState.State.Run);
        WalkState = new PlayerWalkState(this, StateManager, global::PlayerState.State.Walk);
        AttackState = new PlayerAttackState(this, StateManager, global::PlayerState.State.Attack);
        DashState = new PlayerDashState(this, StateManager, global::PlayerState.State.Dash);

        InitializeController();
    }
    protected void OnControllerStart()
    {
        InputHandler = GetComponent<PlayerInputHandler>();
        Animator = GetComponentInChildren<Animator>();
        laserSightAimComponent = GetComponent<LaserSightAim>();

        playerStats.InitializeStats();

        StateManager.Initialize(IdleState);
    }

    protected void OnControllerUpdate() // this is like Update function
    {
        StateManager.CurrentState.LogicalUpdates();
    }
    protected void OnControllerFixedUpdate()
    {
        StateManager.CurrentState.PhysicalUpdates();
    }

    public virtual void InitializeController()
    {
        isDead = false;
        timeForNextAttack = 0;
    }

    public Vector3 GetPointerPosByGroundPlane() // returns the mouse pointer point on the ground
    {
        Vector3 hitPoint = new Vector3();

        // this creates a horizontal plane passing through this object's center
        var plane = new Plane(Vector3.up, transform.position);
        // create a ray from the mousePosition
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        // plane.Raycast returns the distance from the ray start to the hit point
        float distance;
        if (plane.Raycast(ray, out distance))
        {
            // some point of the plane was hit - get its coordinates
            hitPoint = ray.GetPoint(distance);
            // use the hitPoint to aim your cannon
        }

        return hitPoint;
    }

    protected void OnDead()
    {
        // Dead animation ... etc
        Debug.Log("Player is Dead !");
        isDead = true;
    }
    public void TakeDamage(float damage)
    {
        // Take damage animation

        FloatingTextManager.singleton.Show("- " + damage, 20, Color.red, transform.position, Vector3.up * 50, 2.0f);

        Health -= damage;

        PlayerTakeDamage.Invoke(damage);

        if (Health <= 0)
        {
            OnDead();
        }
    }

    public void Shoot(GameObject bulletPrefab, Vector3 startPosition, Quaternion startRotation)
    {
        Instantiate(bulletPrefab, ShootingStartPoint.transform.position, ShootingStartPoint.transform.rotation);
    }

    public void Move(Vector3 direction, float speed)
    {
        gameObject.transform.position += direction * speed * Time.deltaTime;
        gameObject.transform.forward = direction;
    }
}
