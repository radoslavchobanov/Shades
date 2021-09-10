using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalkState : PlayerGroundState
{
    public PlayerWalkState(PlayerController playerController, PlayerStateManager stateManager, State state)
     : base(playerController, stateManager, state)
    { }

    public override void DoChecks()
    {
        base.DoChecks();

        if (playerController.Stamina.current >= playerController.Stamina.GetMaxValue())
            stateManager.ChangeState(playerController.RunState);
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
        
        if (moveInput.x == 0 && moveInput.y == 0) // if current input is (0, 0) --> change player state to Idle
        {
            stateManager.ChangeState(playerController.IdleState);
        }
    }

    public override void PhysicalUpdates()
    {
        base.PhysicalUpdates();
        
        playerController.Animator.SetFloat("Speed", 0.5f, 0.1f, Time.deltaTime);

        Vector3 moveDirection = Vector3.forward * -moveInput.x + Vector3.right * moveInput.y;

        playerController.Move(moveDirection, playerController.Walkspeed);
    }
}
