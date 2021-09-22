using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeadState : PlayerState
{
    private float deadTimer;

    public PlayerDeadState(PlayerController playerController, PlayerStateManager stateManager, State state)
     : base(playerController, stateManager, state)
    { }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();

        playerController.InputHandler.enabled = false;

        // Dead animation, sound ... etc
        playerController.Animator.Play("Dead");

        deadTimer = playerController.Animator.GetCurrentAnimatorStateInfo(0).length;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicalUpdates()
    {
        base.LogicalUpdates();
    }

    public override void PhysicalUpdates()
    {
        base.PhysicalUpdates();

        if (Time.time - startTime >= deadTimer)
        {
            // on deadTime expires --> autospawn the Player from the beginning, etc ...
        }
    }
}
