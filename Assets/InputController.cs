using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

[Serializable] public class MoveInputEvent : UnityEvent<float, float> {}

public class InputController : MonoBehaviour
{
    InputSystem inputs;
    public MoveInputEvent moveInputEvent;

    private void Awake()   
    {
        inputs = new InputSystem();
    }

    private void OnEnable() 
    {
        inputs.GroundMovement.Enable();
        inputs.GroundMovement.HorizontalMovement.performed += OnMovePerformed;
        inputs.GroundMovement.HorizontalMovement.canceled += OnMovePerformed;
    }

    private void OnMovePerformed(InputAction.CallbackContext context)
    {
        Vector2 moveInput = context.ReadValue<Vector2>();
        moveInputEvent.Invoke(moveInput.x, moveInput.y);

        // Debug.Log($"Move Input: {moveInput}");
    }
}
