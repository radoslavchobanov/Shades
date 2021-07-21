using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float movementSpeed;

    float horizontal;
    float vertical;

    protected void OnAwake() 
    {
        InitializeVars();
    }
    protected void OnStart() 
    {

    }

    protected void OnUpdate()
    {
        Move();
    }

    private void InitializeVars()
    {
        movementSpeed = 5f;

        horizontal = 0f;
        vertical = 0f;
    }

    private void Move()
    {
        Vector3 moveDirection = Vector3.forward * horizontal + Vector3.right * vertical;
        transform.position += moveDirection * movementSpeed * Time.deltaTime;
    }

    public void OnMoveInput(float horizontal, float vertical)
    {
        this.horizontal = -horizontal;
        this.vertical = vertical;
    }
}
