using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class CharacterController : MonoBehaviour
{
    public float movementSpeed = 5.0f;

    float horizontal;
    float vertical;

    private void Start() 
    {
    }

    private void Update() 
    {
        Move();
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
