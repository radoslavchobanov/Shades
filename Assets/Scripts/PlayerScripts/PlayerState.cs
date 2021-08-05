using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerState
{
    protected PlayerController playerController;
    protected PlayerStateMachine stateMachine;

    protected float startTime;

    public enum State
    {
        Idle,
        Walking,
        Running,
        Attacking
    };
    public State _State { get; private set; }

    public PlayerState(PlayerController playerController, PlayerStateMachine stateMachine, State state)
    {
        this.playerController = playerController;
        this.stateMachine = stateMachine;
        this._State = state;
    }

    public virtual void Enter()
    {
        DoChecks();
        startTime = Time.time;
    }
    public virtual void LogicalUpdates()
    {

    }
    public virtual void PhysicalUpdates()
    {
        DoChecks();
    }
    public virtual void Exit()
    {

    }
    public virtual void DoChecks()
    {

    }
}
