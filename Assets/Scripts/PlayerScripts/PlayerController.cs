using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;
using System;

public class PlayerController : MonoBehaviour
{
    #region StateMachine
    public PlayerStateMachine StateMachine { get; private set; }
    public PlayerIdleState IdleState { get; private set; }
    public PlayerMoveState MoveState { get; private set; }
    public PlayerAttackState AttackState { get; private set; }

    #endregion


    #region PlayerInput
    public PlayerInputHandler InputHandler { get; private set; }

    #endregion


    #region Controller variables
    [SerializeField] private float attackSpeed; // attacks per second
    [SerializeField] private float movementSpeed;
    [SerializeField] private float health;
    [SerializeField] private PlayerState.State currentState;
    private Animator animator;
    public Slider healthBarSlider;
    public bool isDead;

    #endregion


    #region GETTERS AND SETTERS
    public float AttackSpeed { get => attackSpeed; set => attackSpeed = value; }
    public float MovementSpeed { get => movementSpeed; set => movementSpeed = value; }
    public float Health { get => health; set => health = value; }
    public PlayerState.State CurrentState { get => currentState; set => currentState = value; }
    public Animator Animator { get => animator; set => animator = value; }

    #endregion


    #region References
    [NonSerialized] public AimAtPointer aimAtPointerComponent; // to enabled AimAtPointer.cs script

    #endregion

    #region Shooting vars
    public GameObject ShootingStartPoint; // the point from where the bullet fires
    public GameObject BulletPrefab; // prefab of the bullet. no shit.
    public float timeForNextAttack;

    #endregion


    protected void OnControllerAwake()
    {
        StateMachine = new PlayerStateMachine();
        IdleState = new PlayerIdleState(this, StateMachine, global::PlayerState.State.Idle);
        MoveState = new PlayerMoveState(this, StateMachine, global::PlayerState.State.Running);
        AttackState = new PlayerAttackState(this, StateMachine, global::PlayerState.State.Attacking);

        InitializeController();
    }
    protected void OnControllerStart()
    {
        InputHandler = GetComponent<PlayerInputHandler>();
        Animator = GetComponentInChildren<Animator>();
        aimAtPointerComponent = GetComponent<AimAtPointer>();

        StateMachine.Initialize(IdleState);
    }

    protected void OnControllerUpdate() // this is like Update function
    {
        StateMachine.CurrentState.LogicalUpdates();
    }
    protected void OnControllerFixedUpdate()
    {
        StateMachine.CurrentState.PhysicalUpdates();
    }

    public virtual void InitializeController()
    {
        if (healthBarSlider == null)
            print("Player's healthbar is not initialised !!!");
        else
        {
            healthBarSlider.value = healthBarSlider.maxValue = Health;
        }
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
        Debug.Log("Player takes " + damage + " damage");

        Health -= damage;
        healthBarSlider.value = Health;

        if (Health <= 0)
        {
            OnDead();
        }
    }

    public void Shoot(GameObject bulletPrefab, Vector3 startPosition, Quaternion startRotation)
    {
        GameObject bullet = Instantiate(bulletPrefab, ShootingStartPoint.transform.position, ShootingStartPoint.transform.rotation);

        bullet.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * 1000);
        
        timeForNextAttack = Time.time + (1 / AttackSpeed);
    }
}
