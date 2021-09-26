using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
#region Panels
    public GameObject mainPanel;
    public GameObject optionsPanel;
#endregion

#region MainPanelItems
    public GameObject newGameButtonObj;
    private Button newGameButton;
    public GameObject resumeButtonObj;
    private Button resumeButton;

    public GameObject optionsButtonObj;
    private Button optionsButton;

    public GameObject quitButtonObj;
    private Button quitButton;
#endregion

#region OptionsPanelItems
    public GameObject backButtonObj;
    private Button backButton;

    public GameObject resolutionDropdownObj;
    private Dropdown resolutionDropdown;

    public GameObject fpsToggleObj;
    private Toggle fpsToggle;

    public struct ResolutionInfo
    {
        int width {get {return this.width;} set {this.width = width;}}
        int height {get {return this.height;} set {this.height = height;}}
        string name {get {return this.name;} set {this.name = name;}}
    }
    public static ResolutionInfo Resolution;

    public void SetResolution()
    {
        Screen.SetResolution(1920, 1080, true);
    }
#endregion

    private void Awake() 
    {
    #region MainPanelItems
        newGameButton = newGameButtonObj.GetComponent<Button>();
        resumeButton = resumeButtonObj.GetComponent<Button>();
        optionsButton = optionsButtonObj.GetComponent<Button>();
        quitButton = quitButtonObj.GetComponent<Button>();
    #endregion

    #region OptionsPanelItems
        backButton = backButtonObj.GetComponent<Button>();
        resolutionDropdown = resolutionDropdownObj.GetComponent<Dropdown>();
        fpsToggle = fpsToggleObj.GetComponent<Toggle>();
    #endregion
    }

    private void Start()
    {
        newGameButton?.onClick.AddListener(OnNewGameButtonClicked);
        resumeButton?.onClick.AddListener(OnResumeButtonClicked);
        optionsButton?.onClick.AddListener(OnOptionButtonClicked);
        quitButton?.onClick.AddListener(OnQuitButtonClicked);
        
        backButton.onClick.AddListener(OnBackButtonClicked);

        fpsToggle.onValueChanged.AddListener(OnFPSToggled);

        SetResolution();
    }

    private void OnEnable() 
    {
        mainPanel.SetActive(true);
        optionsPanel.SetActive(false);
    }

    private void OnNewGameButtonClicked()
    {
        GameStateManager.singleton.ToPlayScene();
    }
    private void OnResumeButtonClicked() => GameStateManager.singleton.ChangeState(GameStateManager.singleton.PlayState);
    private void OnOptionButtonClicked()
    {
        mainPanel.SetActive(false);
        optionsPanel.SetActive(true);
    }
    private void OnQuitButtonClicked()
    {
        // EXITS from the Play mode in unity / quits the application

        if (GameStateManager.singleton.CurrentScene.name == GameResources.singleton.PlayScene)
            GameStateManager.singleton.ToMainMenuScene();
        else if (GameStateManager.singleton.CurrentScene.name == GameResources.singleton.MainMenuScene)
            UnityEditor.EditorApplication.isPlaying = false;
    }

    private void OnBackButtonClicked()
    {
        mainPanel.SetActive(true);
        optionsPanel.SetActive(false);
    }

    private void OnFPSToggled(bool toggle)
    {
        GameUIManager.singleton.FPSTextObj.SetActive(toggle);
    }
}