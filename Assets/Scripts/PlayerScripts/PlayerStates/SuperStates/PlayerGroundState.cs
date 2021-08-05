using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundState : PlayerState
{
    protected Vector2 moveInput;

    public PlayerGroundState(PlayerController playerController, PlayerStateMachine stateMachine, State state)
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

        moveInput = playerController.InputHandler.GroundMovementInput;
    }
    public override void PhysicalUpdates()
    {
        base.PhysicalUpdates();
    }

}
