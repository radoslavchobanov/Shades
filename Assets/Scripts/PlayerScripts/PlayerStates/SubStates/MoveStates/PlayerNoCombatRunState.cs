using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNoCombatRunState : PlayerMoveState
{
    public PlayerNoCombatRunState(PlayerController playerController, PlayerStateManager stateManager, State state)
     : base(playerController, stateManager, state)
    { }

    public override void DoChecks()
    {
        base.DoChecks();
        
        if (playerController.Stamina.current <= playerController.Stamina.GetMinValue())
            stateManager.ChangeState(playerController.NoCombatWalkState);
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
        
        playerController.Stamina.UpdateDegenerate();
    }

    public override void PhysicalUpdates()
    {
        base.PhysicalUpdates();
        
        playerController.Move(moveDirection, playerController.RunSpeed);
    }
    
    public override void AnimationUpdates()
    {
        base.AnimationUpdates();
    }
}
