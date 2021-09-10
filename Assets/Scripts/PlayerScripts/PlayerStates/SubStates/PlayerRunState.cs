using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunState : PlayerGroundState
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

        if (moveInput.x == 0 && moveInput.y == 0) // if current input is (0, 0) --> change player state to Idle
        {
            stateManager.ChangeState(playerController.IdleState);
        }

        else if (playerController.Stamina.current <= playerController.Stamina.GetMinValue())
        {
            stateManager.ChangeState(playerController.WalkState);
        }
    }

    public override void PhysicalUpdates() // Physical updates while in Moving state
    {
        base.PhysicalUpdates();
        
        playerController.Stamina.UpdateDegenerate();

        playerController.Animator.SetFloat("Speed", 1, 0.1f, Time.deltaTime);

        Vector3 moveDirection = Vector3.forward * -moveInput.x + Vector3.right * moveInput.y;

        playerController.Move(moveDirection, playerController.RunSpeed);
    }
}
