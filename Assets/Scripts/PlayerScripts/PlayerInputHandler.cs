using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    public Vector2 GroundMovementInput { get; private set; }

    public void OnMoveInput(InputAction.CallbackContext context)
    {
        GroundMovementInput = context.ReadValue<Vector2>();
    }

    public void OnLeftMouseClick(InputAction.CallbackContext context)
    {
        Debug.Log("Left mouse click");
    }
}
