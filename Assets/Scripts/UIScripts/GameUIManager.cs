using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour
{
    #region Singleton 
    public static GameUIManager singleton;
    #endregion

    
    public GameObject PauseMenu;
    public Slider PlayerHealthbar;
    public Slider PlayerEnergyBar;
    public Slider PlayerStaminaBar;

    private void Awake() 
    {
        if (singleton == null)
            singleton = this;
    }

    private void Start() // Initialize in Start, cuz in Awake there is still no Player created
    {
        // vars init
        PlayerHealthbar.value = PlayerHealthbar.maxValue = Player.singleton.Health;
        PlayerEnergyBar.value = PlayerEnergyBar.maxValue = Player.singleton.Energy.current;
        PlayerStaminaBar.value = PlayerStaminaBar.maxValue = Player.singleton.Stamina.current;

        // event listeners
        Player.singleton.PlayerTakeDamage.AddListener(OnPlayerTakesDamage);
    }

    private void Update()
    {
        PlayerEnergyBar.value = Player.singleton.Energy.current;
        PlayerStaminaBar.value = Player.singleton.Stamina.current;
    }
    
    public void OnPauseStateEnter()
    {
        PauseMenu.SetActive(true);
    }
    public void OnPauseStateExit()
    {
        PauseMenu.SetActive(false);
    }
    private void OnPlayerTakesDamage(float damage)
    {
        PlayerHealthbar.value -= damage;
    }
}
