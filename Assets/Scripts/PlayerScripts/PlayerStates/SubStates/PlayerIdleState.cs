using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerGroundState
{
    public PlayerIdleState(PlayerController playerController, PlayerStateManager stateManager, State state)
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

        if (moveInput.x != 0 || moveInput.y != 0)
        {
            stateManager.ChangeState(playerController.MoveState);
        }
    }

    public override void PhysicalUpdates()
    {
        base.PhysicalUpdates();

        playerController.Animator.SetFloat("Speed", 0, 0.1f, Time.deltaTime);
    }

}
