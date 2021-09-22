using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundState : PlayerState
{
    protected Vector2 moveInput;
    
    protected bool CombatStanceChanged;

    protected bool attacking;

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
        
        CombatStanceCheck();

        // External - Other State Input ---------------------------------
        if (playerController.InputHandler.AttackInput)
        {
            attacking = true;
            stateManager.ChangeState(playerController.AttackState);
        }

        if (playerController.InputHandler.DashInput && playerController.CanDash())
        {
            stateManager.ChangeState(playerController.DashState);
            playerController.InputHandler.DoDash();
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

    private void CombatStanceCheck()
    {
        if (playerController.InputHandler.ChangeStanceInput)
        {
            playerController.CombatStance = !playerController.CombatStance;
            CombatStanceChanged = true;
            playerController.InputHandler.DoChangeStance();
        }
    }
}
