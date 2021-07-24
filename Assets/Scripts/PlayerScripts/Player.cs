using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : PlayerController
{
    public static Player singleton;

    private void Awake() 
    {
        OnControllerAwake();

        if (singleton == null)
            singleton = this;
        else print("More than one Player!!!");
    }

    private void Start() 
    {
        OnControllerStart();
    }

    private void Update() 
    {
        OnControllerUpdate();
    }

    public override void InitializeController()
    {
        base.InitializeController();
        this.Health = 100;
        this.MovementSpeed = 7f;
    }
}
