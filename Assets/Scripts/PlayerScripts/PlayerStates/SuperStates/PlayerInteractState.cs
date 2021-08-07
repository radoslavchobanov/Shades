using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractState : PlayerState
{
    protected float leftMouseClickInput; // 0 -> not clicked || 1 -> clicked

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
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicalUpdates()
    {
        base.LogicalUpdates();

        leftMouseClickInput = playerController.InputHandler.LeftMouseClick;
    }

    public override void PhysicalUpdates()
    {
        base.PhysicalUpdates();
    }
}
