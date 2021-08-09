using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundState : PlayerState
{
    protected Vector2 moveInput;

    private bool leftMouseClickInput;
    private bool rightMouseClickInput;

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

        // External - Other State Input ---------------------------------
        leftMouseClickInput = playerController.InputHandler.LeftMouseClick;
        if (leftMouseClickInput)
        {
            stateMachine.ChangeState(playerController.AttackState);
        }
        // --------------------------------------------------------------


        // AimAtPointer State -------------------------------------------
        // Ugly code !!! FIXME !!!
        rightMouseClickInput = playerController.InputHandler.RightMouseClick;
        if (rightMouseClickInput)
        {
            playerController.aimAtPointerComponent.enabled = !playerController.aimAtPointerComponent.enabled;
            playerController.InputHandler.DoRightMouseClick();
        }
        // --------------------------------------------------------------


        // Internal - GroundStateMovementInput --------------------------
        moveInput = playerController.InputHandler.HorizontalMovementInput;
        // --------------------------------------------------------------
    }
    public override void PhysicalUpdates()
    {
        base.PhysicalUpdates();
    }

}
