using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float movementSpeed = 5.0f;

    float horizontal;
    float vertical;

    Camera camera;

    private void Start() 
    {
        camera = Camera.main;
    }

    private void Update() 
    {
        Vector3 moveDirection = Vector3.forward * vertical + Vector3.right * horizontal;

        transform.position += moveDirection * movementSpeed * Time.deltaTime;

        camera.transform.position += moveDirection * movementSpeed * Time.deltaTime;
    }

    public void OnMoveInput(float vertical, float horizontal)
    {
        this.vertical = -vertical;
        this.horizontal = horizontal;

        // Debug.Log($"Move Input: {vertical}, {horizontal}");
    }
}
