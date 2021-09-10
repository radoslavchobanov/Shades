using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunState : PlayerGroundState
{
    //Stamina code
    float staminaTimer = 1f;
    float lastStaminaTick;
    // ----------

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

        //Stamina code
        lastStaminaTick = Time.time;
        //--------
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicalUpdates() // Logical updates while in Moving state
    {
        base.LogicalUpdates();

        // Stamina code. Move it from here ------------------------------
        if (Time.time - lastStaminaTick >= staminaTimer)
        {
            playerController.Stamina.current -= 1;
            lastStaminaTick = Time.time;
        }
        // ------------------------------

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

        playerController.Animator.SetFloat("Speed", 1, 0.1f, Time.deltaTime);

        Vector3 moveDirection = Vector3.forward * -moveInput.x + Vector3.right * moveInput.y;

        playerController.Move(moveDirection, playerController.RunSpeed);
    }
}
