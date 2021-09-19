using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNoCombatWalkState : PlayerMoveState
{
    public PlayerNoCombatWalkState(PlayerController playerController, PlayerStateManager stateManager, State state)
     : base(playerController, stateManager, state)
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
    }

    public override void PhysicalUpdates()
    {
        base.PhysicalUpdates();
        
        playerController.transform.forward = moveDirection;
        
        playerController.Move(moveDirection, playerController.Walkspeed);
    }
    
    public override void AnimationUpdates()
    {
        base.AnimationUpdates();
        
        playerController.Animator.SetFloat("Combat", 0, 0.1f, Time.deltaTime);
        playerController.Animator.SetFloat("Speed", 0.5f, 0.1f, Time.deltaTime);
    }
}
