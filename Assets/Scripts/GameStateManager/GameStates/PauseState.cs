using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseState : GameState
{
    public PauseState(State state) : base(state)
    { }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();

        Time.timeScale = 0f; // stops PhysicalUpdate

        GameStateManager.singleton.OnPauseStateEnter();

        // Stop player inputs
    }

    public override void Exit()
    {
        base.Exit();

        GameStateManager.singleton.OnPauseStateExit();
    }

    public override void LogicalUpdates()
    {
        base.LogicalUpdates();

        if (escapeClickInput)
        {
            ResumeGame();
        }
    }

    public override void PhysicalUpdates()
    {
        base.PhysicalUpdates();
    }

}
