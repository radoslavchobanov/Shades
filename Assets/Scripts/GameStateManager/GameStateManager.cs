using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    #region Singleton 
    public static GameStateManager singleton;
    #endregion

    [SerializeReference] private GameState currentState;

    #region States
    public PlayState PlayState { get; private set; }
    public PauseState PauseState { get; private set; }

    public GameState CurrentState { get => currentState; private set => currentState = value; }
    #endregion


    #region GameInput
    public GameInputHandler InputHandler { get; private set; }
    #endregion

    private void Awake()
    {
        if (singleton == null)
            singleton = this;

        
        PlayState = new PlayState(global::GameState.State.Play);
        PauseState = new PauseState(global::GameState.State.Pause);
    }

    private void Start()
    {
        InputHandler = GetComponent<GameInputHandler>();

        Initialize(PlayState);
    }

    private void Update()
    {
        CurrentState.LogicalUpdates();
    }

    private void FixedUpdate() // Wont use FixedUpdate/PhysicalUpdate for now --> nothing to move in here, just control states
    { }

    public void Initialize(GameState startingState)
    {
        CurrentState = startingState;
        CurrentState.Enter();
    }
    public void ChangeState(GameState newState)
    {
        CurrentState.Exit();
        CurrentState = newState;
        CurrentState.Enter();
    }
}
