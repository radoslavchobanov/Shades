using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    public Vector2 HorizontalMovementInput { get; private set; }
    public float LeftMouseClick { get; private set; }
    

    public void OnMoveInput(InputAction.CallbackContext context)
    {
        HorizontalMovementInput = context.ReadValue<Vector2>();
    }

    public void OnLeftMouseClick(InputAction.CallbackContext context)
    {
        LeftMouseClick = context.ReadValue<float>();
    }
}
