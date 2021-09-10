using System;
using UnityEngine;

[Serializable]
public class PlayerStats
{
    public float damage; // depends on the player weapon's damage

    public float attackSpeed;
    public float runSpeed;
    public float walkSpeed;
    public float health;
    public float mana; // mana bar for some spells/utilities
    public float armor;
    public Stamina stamina; // a time, the player can run without getting exhausted
    public Energy energy; // a time, the player can shoot without burning out

    public float dashSpeed;
    public float dashDuration;

    public void InitializeStats()
    {
        stamina = new Stamina();
        energy = new Energy();
    }
}