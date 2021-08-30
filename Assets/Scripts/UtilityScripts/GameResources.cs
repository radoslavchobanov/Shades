using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameResources : MonoBehaviour
{
    public static GameResources singleton;

    public string PlayScene = "PlayScene";
    public string MainMenuScene = "MainMenuScene";

    public GameObject redBasicBullet_prefab;
    public GameObject greenBasicBullet_prefab;

    private void Awake() 
    {
        if (singleton == null)
            singleton = this;    
    }
}
