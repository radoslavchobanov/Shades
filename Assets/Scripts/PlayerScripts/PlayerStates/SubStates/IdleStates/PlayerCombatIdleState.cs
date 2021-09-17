using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombatIdleState : PlayerIdleState
{
    public PlayerCombatIdleState(PlayerController playerController, PlayerStateManager stateManager, State state)
     : base(playerController, stateManager, state)
    { }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
        
        playerController.Animator.SetBool("Combat", true);
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
    }

    public override void AnimationUpdates()
    {
        base.AnimationUpdates();
        
        playerController.Animator.SetFloat("SpeedZ", 0, 0.1f, Time.deltaTime);
        playerController.Animator.SetFloat("SpeedX", 0, 0.1f, Time.deltaTime);
    }
}
