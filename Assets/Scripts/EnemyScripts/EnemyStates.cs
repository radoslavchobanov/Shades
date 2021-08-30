using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState
{
    protected EnemyController enemyController;
    protected EnemyStateManager stateManager;

    protected float startTime;

    public enum State
    {
        Idle,
        Roaming,
        MovingToTarget,
        Attacking,
    };
    public State _State { get; private set; }

    public EnemyState(EnemyController enemyController, EnemyStateManager stateManager, State state)
    {
        this.enemyController = enemyController;
        this.stateManager = stateManager;
        this._State = state;
    }

    public virtual void Enter()
    {
        Debugger.Log(enemyController.gameObject, "Enters " + _State + " state");
        enemyController.CurrentState = _State;

        DoChecks();
        startTime = Time.time;
    }
    public virtual void LogicalUpdates()
    {
        Debugger.Log(enemyController.gameObject, "is " + _State);
    }
    public virtual void PhysicalUpdates()
    {   
        DoChecks();
    }
    public virtual void Exit()
    {
        Debugger.Log(enemyController.gameObject, "Exits " + _State + " state");
    }
    public virtual void DoChecks()
    {
    }
}
