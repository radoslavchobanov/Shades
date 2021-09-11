using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeadState : PlayerState
{
    private float deadTimer = 10f;

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

        // Dead animation, sound ... etc
        playerController.Animator.SetBool("Dead", true);
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

        if (Time.time - startTime < 0.5f)
        {
            playerController.Animator.SetBool("Dead", false);
        }
        else if (Time.time - startTime >= deadTimer)
        {
            Exit();
            // on deadTime expires --> autospawn the Player from the beginning, etc ...
        }
    }
}
