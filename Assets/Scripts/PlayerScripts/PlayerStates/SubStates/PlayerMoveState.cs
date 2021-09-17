using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerGroundState
{
    protected Vector3 moveDirection;
    
    public PlayerMoveState(PlayerController playerController, PlayerStateManager stateManager, State state)
     : base(playerController, stateManager, state)
    { }

    public override void DoChecks()
    {
        base.DoChecks();

        if (playerController.Stamina.current <= playerController.Stamina.GetMinValue())
            stateManager.ChangeState(playerController.States.WalkState);
        else stateManager.ChangeState(playerController.States.RunState);
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
            stateManager.ChangeState(playerController.States.IdleState);
        }
        
        moveDirection = new Vector3(moveInput.y, 0f, -moveInput.x);
    }

    public override void PhysicalUpdates()
    {
        base.PhysicalUpdates();
    }
    
    public override void AnimationUpdates()
    {
        base.AnimationUpdates();
    }
}
