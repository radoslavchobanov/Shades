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

    #endregion


    #region PlayerInput
    public PlayerInputHandler InputHandler { get; private set; }

    #endregion


    #region Controller variables
    [SerializeField] private float movementSpeed;
    [SerializeField] private float health;
    [SerializeField] private PlayerState.State currentState;
    private Animator animator;
    public Slider healthBarSlider;
    public bool isDead;

    #endregion


    #region GETTERS AND SETTERS
    public float MovementSpeed { get => movementSpeed; set => movementSpeed = value; }
    public float Health { get => health; set => health = value; }
    public PlayerState.State CurrentState { get => currentState; set => currentState = value; }
    public Animator Animator { get => animator; set => animator = value; }

    #endregion


    #region References

    #endregion


    protected void OnControllerAwake()
    {
        StateMachine = new PlayerStateMachine();
        IdleState = new PlayerIdleState(this, StateMachine, global::PlayerState.State.Idle);
        MoveState = new PlayerMoveState(this, StateMachine, global::PlayerState.State.Running);

        InitializeController();
    }
    protected void OnControllerStart()
    {
        InputHandler = GetComponent<PlayerInputHandler>();
        Animator = GetComponentInChildren<Animator>();

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
}
