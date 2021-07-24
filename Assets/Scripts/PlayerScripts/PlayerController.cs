using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private float health;

    public Slider healthBarSlider;

    public bool isDead;

#region GETTERS AND SETTERS
    public float MovementSpeed { get => movementSpeed; set => movementSpeed = value;}
    public float Health { get => health; set => health = value;}

#endregion

    float horizontal;
    float vertical;

    protected void OnControllerAwake() 
    {
        InitializeController();
    }
    protected void OnControllerStart()
    {
        if (healthBarSlider == null)
            print("Player's healthbar is not initialised !!!");
        else
        {
            healthBarSlider.value = healthBarSlider.maxValue = Health;
        }

        isDead = false;
    }

    protected void OnControllerUpdate()
    {
        Move();
    }
    protected void OnDead()
    {
        // Dead animation ... etc
        Debug.Log("Player is Dead !");
        isDead = true;
    }

    public virtual void InitializeController() {}

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

    public void TakeDamage(float damage)
    {
        // Take damage animation
        Debug.Log("Player takes " + damage + " damage");

        Health -= damage;
        healthBarSlider.value = Health;
        
        if (Health <= 0)
        {
            OnDead();
        }
    }
}
