using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerGroundState
{
    public PlayerIdleState(PlayerController playerController, PlayerStateMachine stateMachine, State state)
     : base(playerController, stateMachine, state)
    { }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();

        Debugger.Log(playerController.gameObject, "Enters Idle state");

        playerController.CurrentState = _State;
    }

    public override void Exit()
    {
        base.Exit();

        Debugger.Log(playerController.gameObject, "Exits Idle state");
    }
    public override void LogicalUpdates()
    {
        base.LogicalUpdates();

        if (moveInput.x != 0 || moveInput.y != 0)
        {
            stateMachine.ChangeState(playerController.MoveState);
        }
    }

    public override void PhysicalUpdates()
    {
        base.PhysicalUpdates();

        Debugger.Log(playerController.gameObject, "is Idling");

        playerController.Animator.SetFloat("Speed", 0, 0.1f, Time.deltaTime);
    }

}
