using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    // Move input
    public Vector2 HorizontalMovementInput { get; private set; }
    
    // Dash input
    public bool ShiftClicked { get; private set; }

    // Interaction input
    public bool LeftMouseClick { get; private set; }
    // public bool LeftMouseHold { get; private set; }
    public GameObject ObjectClicked { get; private set; }

    // Aim state input
    public bool RightMouseClick { get; private set; }


    public void OnMoveInput(InputAction.CallbackContext context)
    {
        HorizontalMovementInput = context.ReadValue<Vector2>();
    }

    public void OnDashInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            ShiftClicked = true;
        }
    }
    public void DoShiftClick() => ShiftClicked = false;

    public void OnLeftMouseClick(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            LeftMouseClick = true;
            ObjectClicked = GameStateManager.GetMousePointedGameObject();
        }

        else if (context.canceled)
        {
            LeftMouseClick = false;
        }
    }

    public void OnRightMouseClick(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            RightMouseClick = true;
        }
    }
    public void DoRightMouseClick() => RightMouseClick = false;
}
