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
        Debug.Log("Enter Pause State");

        Time.timeScale = 0f; // stops PhysicalUpdate

        // Stop player inputs
    }

    public override void Exit()
    {
        base.Exit();
        Debug.Log("Exit Pause State");
    }

    public override void LogicalUpdates()
    {
        base.LogicalUpdates();

        if (escapeClickInput)
        {
            GameStateManager.singleton.ChangeState(GameStateManager.singleton.PlayState);
            GameStateManager.singleton.InputHandler.DoEscapeClick();
        }
    }

    public override void PhysicalUpdates()
    {
        base.PhysicalUpdates();
    }

}
