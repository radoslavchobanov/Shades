using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombatRunState : PlayerMoveState
{   
    public PlayerCombatRunState(PlayerController playerController, PlayerStateManager stateManager, State state)
     : base(playerController, stateManager, state)
    { }

    public override void DoChecks()
    {
        base.DoChecks();

        if (playerController.Stamina.current <= playerController.Stamina.GetMinValue())
            stateManager.ChangeState(playerController.CombatWalkState);
        else if (playerController.InputHandler.AttackInput)
        {
            attacking = true;
            stateManager.ChangeState(playerController.AttackRunState);
        }
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

        float speedX = Vector3.Dot(moveDirection.normalized, playerController.gameObject.transform.forward);
        float speedZ = Vector3.Dot(moveDirection.normalized, playerController.gameObject.transform.right);
        
        playerController.Animator.SetFloat("Combat", 1, 0.1f, Time.deltaTime);
        playerController.Animator.SetFloat("Speed", 1, 0.1f, Time.deltaTime);
        playerController.Animator.SetFloat("SpeedZ", speedZ, 0.1f, Time.deltaTime);
        playerController.Animator.SetFloat("SpeedX", speedX, 0.1f, Time.deltaTime);
    }
}
