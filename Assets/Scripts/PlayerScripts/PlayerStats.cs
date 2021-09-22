using System;
using UnityEngine;

[Serializable]
public class PlayerStats
{
    public float damage; // depends on the player weapon's damage

    public float attackSpeed;
    public float runSpeed;
    public float walkSpeed;
    public Health health;
    public float mana; // mana bar for some spells/utilities
    public float armor;
    public Stamina stamina; // a time, the player can run without getting exhausted
    public Energy energy; // a time, the player can shoot without burning out

    public float dashSpeed;
    public float dashDuration;
    public float dashCooldown;
    [NonSerialized] public float timeForNextDash;

    public void InitializeStats()
    {
        health = new Health();
        stamina = new Stamina();
        energy = new Energy();
    }
}