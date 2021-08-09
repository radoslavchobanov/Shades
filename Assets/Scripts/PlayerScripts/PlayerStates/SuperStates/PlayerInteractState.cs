using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractState : PlayerState
{
    protected bool isInteractionDone;

    public PlayerInteractState(PlayerController playerController, PlayerStateMachine stateMachine, State state)
        : base(playerController, stateMachine, state)
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
            stateMachine.ChangeState(playerController.IdleState);
    }

    public override void PhysicalUpdates()
    {
        base.PhysicalUpdates();
    }
}
