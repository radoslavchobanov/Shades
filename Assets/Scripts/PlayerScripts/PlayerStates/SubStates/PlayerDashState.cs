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
            stateManager.ChangeState(playerController.States.IdleState);
        }
    }

    public override void PhysicalUpdates()
    {
        base.PhysicalUpdates();
        
        Vector3 direction = playerController.gameObject.transform.forward;
        float speed = playerController.PlayerStats.dashSpeed;

        playerController.gameObject.transform.position += direction * speed * Time.deltaTime;
        playerController.gameObject.transform.forward = direction;
    }
}
