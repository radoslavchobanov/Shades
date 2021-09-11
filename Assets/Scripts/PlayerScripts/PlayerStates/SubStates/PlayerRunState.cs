using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunState : PlayerGroundState
{
    private Vector3 moveDirection;

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

        // moveDirection = Vector3.forward * -moveInput.x + Vector3.right * moveInput.y;
        moveDirection = new Vector3(moveInput.y, 0f, -moveInput.x);
        Debug.Log(moveDirection);
    }

    public override void PhysicalUpdates() // Physical updates while in Moving state
    {
        base.PhysicalUpdates();
        
        playerController.Stamina.UpdateDegenerate();

        UpdateMovement();
    }

    public override void AnimationUpdates()
    {
        base.AnimationUpdates();

        float speedX = Vector3.Dot(moveDirection.normalized, playerController.gameObject.transform.forward);
        float speedZ = Vector3.Dot(moveDirection.normalized, playerController.gameObject.transform.right);
        
        playerController.Animator.SetFloat("SpeedZ", speedZ, 0.1f, Time.deltaTime);
        playerController.Animator.SetFloat("SpeedX", speedX, 0.1f, Time.deltaTime);
    }

    private void UpdateMovement()
    {
        // Vector3 moveDirection = new Vector3(moveInput.x, 0f, moveInput.y);
        playerController.Move(moveDirection, playerController.RunSpeed);
    }
}
