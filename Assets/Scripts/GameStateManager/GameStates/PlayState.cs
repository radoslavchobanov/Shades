using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayState : GameState
{
    public PlayState(State state) : base(state)
    { }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();

        Time.timeScale = 1f; // starts PhysicalUpdate

        // start player inputs
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicalUpdates()
    {
        base.LogicalUpdates();
        
        if (escapeClickInput)
        {
            PauseGame();
        }
    }

    public override void PhysicalUpdates()
    {
        base.PhysicalUpdates();
    }
}
