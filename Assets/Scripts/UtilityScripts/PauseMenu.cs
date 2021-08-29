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
        resumeButton = resumeButtonObj.GetComponent<Button>();
        optionsButton = optionsButtonObj.GetComponent<Button>();
        quitButton = quitButtonObj.GetComponent<Button>();
    #endregion

    #region OptionsPanelItems
        backButton = backButtonObj.GetComponent<Button>();
        resolutionDropdown = resolutionDropdownObj.GetComponent<Dropdown>();
    #endregion
    }

    private void Start()
    {
        resumeButton.onClick.AddListener(OnResumeButtonClicked);
        optionsButton.onClick.AddListener(OnOptionButtonClicked);
        quitButton.onClick.AddListener(OnQuitButtonClicked);
        
        backButton.onClick.AddListener(OnBackButtonClicked);

        SetResolution();
    }

    private void OnEnable() 
    {
        mainPanel.SetActive(true);
        optionsPanel.SetActive(false);
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
        UnityEditor.EditorApplication.isPlaying = false;
    }

    private void OnBackButtonClicked()
    {
        mainPanel.SetActive(true);
        optionsPanel.SetActive(false);
    }
}