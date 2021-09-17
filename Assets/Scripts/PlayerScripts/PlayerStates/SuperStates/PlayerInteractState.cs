using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractState : PlayerState
{
    protected bool isInteractionDone;

    public PlayerInteractState(PlayerController playerController, PlayerStateManager stateManager, State state)
        : base(playerController, stateManager, state)
    { }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();

        isInteractionDone = false;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicalUpdates()
    {
        base.LogicalUpdates();

        if (isInteractionDone)
            stateManager.ChangeState(playerController.States.IdleState);
    }

    public override void PhysicalUpdates()
    {
        base.PhysicalUpdates();
    }
}
