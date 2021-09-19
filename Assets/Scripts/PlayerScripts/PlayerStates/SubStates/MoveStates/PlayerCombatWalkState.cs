using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombatWalkState : PlayerMoveState
{
    public PlayerCombatWalkState(PlayerController playerController, PlayerStateManager stateManager, State state)
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
        
        playerController.Move(moveDirection, playerController.Walkspeed);
    }
    
    public override void AnimationUpdates()
    {
        base.AnimationUpdates();
        
        float speedX = Vector3.Dot(moveDirection.normalized, playerController.gameObject.transform.forward);
        float speedZ = Vector3.Dot(moveDirection.normalized, playerController.gameObject.transform.right);
        
        playerController.Animator.SetFloat("Combat", 1, 0.1f, Time.deltaTime);
        playerController.Animator.SetFloat("Speed", 0.5f, 0.1f, Time.deltaTime);
        playerController.Animator.SetFloat("SpeedZ", speedZ, 0.1f, Time.deltaTime);
        playerController.Animator.SetFloat("SpeedX", speedX, 0.1f, Time.deltaTime);
    }
}