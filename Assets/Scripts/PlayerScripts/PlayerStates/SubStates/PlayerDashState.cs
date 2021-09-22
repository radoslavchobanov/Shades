using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashState : PlayerGroundState
{
    public PlayerDashState(PlayerController playerController, PlayerStateManager stateManager, State state) 
    : base(playerController, stateManager, state)
    {}

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();

        playerController.PlayerStats.timeForNextDash = startTime + playerController.PlayerStats.dashCooldown;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicalUpdates()
    {
        base.LogicalUpdates();
        
        if (Time.time - startTime >= playerController.PlayerStats.dashDuration)
        {
            stateManager.ChangeState(playerController.IdleState);
        }
    }

    public override void PhysicalUpdates()
    {
        base.PhysicalUpdates();

        var moveDirection = new Vector3(moveInput.y, 0f, -moveInput.x);

        playerController.Move(moveDirection, playerController.PlayerStats.dashSpeed);
    }
}
