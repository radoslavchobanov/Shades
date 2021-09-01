using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerState
{
    protected PlayerController playerController;
    protected PlayerStateManager stateManager;

    protected float startTime;

    public enum State
    {
        Idle,
        Move,
        Attack,
        Dash,
    };
    public State _State { get; private set; }

    public PlayerState(PlayerController playerController, PlayerStateManager stateManager, State state)
    {
        this.playerController = playerController;
        this.stateManager = stateManager;
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
        Debugger.Log(playerController.gameObject, "is " + _State);
    }
    public virtual void PhysicalUpdates()
    {   
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
