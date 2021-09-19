using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerGroundState
{
    protected Vector3 moveDirection;
    
    public PlayerMoveState(PlayerController playerController, PlayerStateManager stateManager, State state)
     : base(playerController, stateManager, state)
    { }

    public override void DoChecks()
    {
        base.DoChecks();
        
        if (!CombatStanceChanged)
            return;

        if (playerController.CombatStance)
        {
            CombatStanceChanged = false;
            stateManager.ChangeState(playerController.CombatRunState);
        }
        else if (!playerController.CombatStance)
        {
            CombatStanceChanged = false;
            stateManager.ChangeState(playerController.NoCombatRunState);
        }
    }

    public override void Enter()
    {
        base.Enter();
        
        CombatStanceChanged = true;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicalUpdates()
    {
        base.LogicalUpdates();
        
        if (moveInput.x == 0 && moveInput.y == 0) // if current input is (0, 0) --> change player state to Idle
        {
            stateManager.ChangeState(playerController.IdleState);
        }
        
        moveDirection = new Vector3(moveInput.y, 0f, -moveInput.x);
    }

    public override void PhysicalUpdates()
    {
        base.PhysicalUpdates();
    }
    
    public override void AnimationUpdates()
    {
        base.AnimationUpdates();
    }
}
