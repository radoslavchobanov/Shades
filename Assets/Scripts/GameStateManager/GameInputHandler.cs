using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameInputHandler : MonoBehaviour
{
    public bool EscapeClick { get; private set; }

    public void OnEscapeClick(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            EscapeClick = true;
        }
    }

    public void DoEscapeClick()
    {
        EscapeClick = false;
    }
}
