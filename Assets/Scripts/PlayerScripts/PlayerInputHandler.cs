using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    public Vector2 HorizontalMovementInput { get; private set; }

    public bool LeftMouseClick { get; private set; }
    public GameObject ObjectClicked { get; private set; }


    public void OnMoveInput(InputAction.CallbackContext context)
    {
        HorizontalMovementInput = context.ReadValue<Vector2>();
    }

    public void OnLeftMouseClick(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            LeftMouseClick = true;
            ObjectClicked = GetClickedGameObject();
        }
    }
    public void DoInteract() => LeftMouseClick = false;

    private GameObject GetClickedGameObject()
    {
        RaycastHit hit;

        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
        {
            return hit.transform.gameObject;
        }
        return null;
    }
}
