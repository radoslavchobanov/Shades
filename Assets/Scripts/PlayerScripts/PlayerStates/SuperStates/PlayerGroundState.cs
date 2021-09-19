using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundState : PlayerState
{
    protected Vector2 moveInput;
    
    protected bool CombatStanceChanged;

    public PlayerGroundState(PlayerController playerController, PlayerStateManager stateManager, State state)
        : base(playerController, stateManager, state)
    { }

    public override void DoChecks()
    {
        base.DoChecks();
    }
    public override void Enter()
    {
        base.Enter();
        
        playerController.laserSightAimComponent.enabled = playerController.CombatStance;
    }
    public override void Exit()
    {
        base.Exit();
    }
    public override void LogicalUpdates()
    {
        base.LogicalUpdates();

        // External - Other State Input ---------------------------------
        if (playerController.InputHandler.LeftMouseClick)
        {
            stateManager.ChangeState(playerController.AttackState);
        }

        if (playerController.InputHandler.ShiftClicked)
        {
            stateManager.ChangeState(playerController.DashState);
            playerController.InputHandler.DoShiftClick();
        }
        // --------------------------------------------------------------


        // AimAtPointer State -------------------------------------------
        // Ugly code !!! FIXME !!!
        if (playerController.InputHandler.RightMouseClick)
        {
            playerController.CombatStance = !playerController.CombatStance;
            CombatStanceChanged = true;
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
