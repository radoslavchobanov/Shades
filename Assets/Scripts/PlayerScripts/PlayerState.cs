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
        Debugger.Log(playerController.gameObject, "Enters " + _State + " state");
        playerController.CurrentState = _State;

        DoChecks();
        startTime = Time.time;
    }
    public virtual void LogicalUpdates()
    {
    }
    public virtual void PhysicalUpdates()
    {
        Debugger.Log(playerController.gameObject, "is " + _State);
        
        DoChecks();
    }
    public virtual void Exit()
    {
        Debugger.Log(playerController.gameObject, "Exits " + _State + " state");
    }
    public virtual void DoChecks()
    {
    }
}
