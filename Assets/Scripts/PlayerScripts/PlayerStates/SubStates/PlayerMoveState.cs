using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerGroundState
{
    public PlayerMoveState(PlayerController playerController, PlayerStateMachine stateMachine, State state)
     : base(playerController, stateMachine, state)
    { }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();

        Debugger.Log(playerController.gameObject, "Enters Move state");

        playerController.CurrentState = _State;
    }

    public override void Exit()
    {
        base.Exit();

        Debugger.Log(playerController.gameObject, "Exits Move state");
    }

    public override void LogicalUpdates() // Logical updates while in Moving state
    {
        base.LogicalUpdates();

        if (moveInput.x == 0 && moveInput.y == 0) // if current input is (0, 0) --> change player state to Idle
        {
            stateMachine.ChangeState(playerController.IdleState);
        }
    }

    public override void PhysicalUpdates() // Physical updates while in Moving state !!! Executes just after Update() ends
    {
        base.PhysicalUpdates();

        playerController.Animator.SetFloat("Speed", 1, 0.1f, Time.deltaTime);

        Debugger.Log(playerController.gameObject, "is Moving");

        Vector3 moveDirection = Vector3.forward * -moveInput.x + Vector3.right * moveInput.y;
        playerController.gameObject.transform.position += moveDirection * playerController.MovementSpeed * Time.deltaTime;
        playerController.gameObject.transform.forward = moveDirection;
    }
}