using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    // Move input
    public Vector2 HorizontalMovementInput { get; private set; }
    
    // Dash input
    public bool DashInput { get; private set; }

    // Attack input
    public bool AttackInput { get; private set; }
    public GameObject ObjectClicked { get; private set; }

    // Stance input
    public bool ChangeStanceInput { get; private set; }


    public void OnMoveInput(InputAction.CallbackContext context)
    {
        HorizontalMovementInput = context.ReadValue<Vector2>();
    }

    public void OnDashInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            DashInput = true;
        }
    }
    public void DoDash() => DashInput = false;

    public void OnAttackInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            AttackInput = true;
            ObjectClicked = GameStateManager.GetMousePointedGameObject();
        }

        else if (context.canceled)
        {
            AttackInput = false;
        }
    }

    public void OnChangeStanceInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            ChangeStanceInput = true;
        }
    }
    public void DoChangeStance() => ChangeStanceInput = false;
}
