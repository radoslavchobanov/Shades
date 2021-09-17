using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunState : PlayerMoveState
{
    public PlayerRunState(PlayerController playerController, PlayerStateManager stateManager, State state)
     : base(playerController, stateManager, state)
    { }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();

        playerController.Stamina.StartDegenerate();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicalUpdates() // Logical updates while in Moving state
    {
        base.LogicalUpdates();
        
        playerController.Stamina.UpdateDegenerate();
    }

    public override void PhysicalUpdates() // Physical updates while in Moving state
    {
        base.PhysicalUpdates();

        playerController.Move(moveDirection, playerController.RunSpeed);
    }

    public override void AnimationUpdates()
    {
        base.AnimationUpdates();

        float speedX = Vector3.Dot(moveDirection.normalized, playerController.gameObject.transform.forward);
        float speedZ = Vector3.Dot(moveDirection.normalized, playerController.gameObject.transform.right);
        
        playerController.Animator.SetFloat("SpeedZ", speedZ, 0.1f, Time.deltaTime);
        playerController.Animator.SetFloat("SpeedX", speedX, 0.1f, Time.deltaTime);
    }
}
