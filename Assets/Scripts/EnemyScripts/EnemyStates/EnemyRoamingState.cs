using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRoamingState : EnemyState
{
    public EnemyRoamingState(EnemyController enemyController, EnemyStateManager stateManager, State state) 
    : base(enemyController, stateManager, state)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicalUpdates()
    {
        base.LogicalUpdates();

        enemyController.RoamAround();
    }

    public override void PhysicalUpdates()
    {
        base.PhysicalUpdates();
    }
}
