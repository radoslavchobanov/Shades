using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public class GameState
{
    #region Inputs
    protected bool escapeClickInput;

    #endregion

    protected float startTime;

    [SerializeField]
    public enum State
    {
        Play,
        Pause,
        Menu,
        LoadingScreen,
        CutScene,
        //etc
    };
    public State _State { get; private set; }

    public GameState(State state)
    {
        this._State = state;
    }

    public virtual void Enter()
    {
        Debugger.Log("Game enters " + _State + " state");

        DoChecks();
        startTime = Time.time;
    }
    public virtual void LogicalUpdates()
    {
        Debugger.Log("Game is " + _State);

        escapeClickInput = GameStateManager.singleton.InputHandler.EscapeClick; // check for clicked escape
    }
    public virtual void PhysicalUpdates()
    {
        DoChecks();
    }
    public virtual void Exit()
    {
        Debugger.Log("Game exits " + _State + " state");
    }
    public virtual void DoChecks()
    {
    }

    protected void PauseGame()
    {
        GameStateManager.singleton.ChangeState(GameStateManager.singleton.PauseState);
        GameStateManager.singleton.InputHandler.DoEscapeClick();
    }
    protected void ResumeGame()
    {
        GameStateManager.singleton.ChangeState(GameStateManager.singleton.PlayState);
        GameStateManager.singleton.InputHandler.DoEscapeClick();
    }

}