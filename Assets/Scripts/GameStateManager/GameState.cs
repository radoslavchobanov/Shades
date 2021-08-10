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
        DoChecks();
        startTime = Time.time;
    }
    public virtual void LogicalUpdates()
    {
        escapeClickInput = GameStateManager.singleton.InputHandler.EscapeClick; // check for clicked escape
    }
    public virtual void PhysicalUpdates()
    {
        DoChecks();
    }
    public virtual void Exit()
    {
    }
    public virtual void DoChecks()
    {
    }
}