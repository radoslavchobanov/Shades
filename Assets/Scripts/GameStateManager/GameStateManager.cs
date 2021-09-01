using UnityEngine;
using UnityEngine.SceneManagement;

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

    public Scene CurrentScene { get; private set; }

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

        CurrentScene = SceneManager.GetActiveScene();
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
    private void ChangeScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
        CurrentScene = SceneManager.GetActiveScene();
    }

    public void ToPlayScene()
    {
        ChangeScene(GameResources.singleton.PlayScene);
        ChangeState(PlayState);
    }
    public void ToMainMenuScene()
    {
        ChangeScene(GameResources.singleton.MainMenuScene);
        ChangeState(PauseState);
    }

    // Utility Functions ---------------------
    public static GameObject GetMousePointedGameObject()
    {
        RaycastHit hit;

        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            return hit.transform.gameObject;
        return null;
    }
    // ---------------------------------------
}
