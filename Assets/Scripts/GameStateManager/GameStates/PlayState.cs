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
        Debug.Log("Enter Play State");

        Time.timeScale = 1f; // starts PhysicalUpdate

        // start player inputs
    }

    public override void Exit()
    {
        base.Exit();
        Debug.Log("Exit Play State");
    }

    public override void LogicalUpdates()
    {
        base.LogicalUpdates();
        
        if (escapeClickInput)
        {
            GameStateManager.singleton.ChangeState(GameStateManager.singleton.PauseState);
            GameStateManager.singleton.InputHandler.DoEscapeClick();
        }
    }

    public override void PhysicalUpdates()
    {
        base.PhysicalUpdates();
    }
}
