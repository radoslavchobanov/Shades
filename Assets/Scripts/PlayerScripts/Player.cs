using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : PlayerController
{
    #region Singleton
    public static Player singleton;
    #endregion

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

    private void FixedUpdate()
    {
        OnControllerFixedUpdate();
    }
    private void LateUpdate() 
    {
        OnControllerLateUpdate();    
    }

    public override void InitializeController()
    {
        base.InitializeController();
    }
}
