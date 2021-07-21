using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : PlayerController
{
    public static Player singleton;

    private void Awake() 
    {
        if (singleton == null)
            singleton = this;
        else print("More than one Player!!!");

        OnAwake();
    }

    private void Start() 
    {

    }

    private void Update() 
    {
        OnUpdate();
    }
}
