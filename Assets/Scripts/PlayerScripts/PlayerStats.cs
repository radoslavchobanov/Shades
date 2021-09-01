using System;

[Serializable]
public class PlayerStats
{
    public float damage; // depends on the player weapon's damage

    public float attackSpeed;
    public float movementSpeed;
    public float walkingSpeed;
    public float health;
    public float stamina; // a time, the player can run without getting exhausted
    public float energy; // a time, the player can shoot without burning out
    public float mana; // mana bar for some spells/utilities
    public float armor;

    public float dashSpeed;
    public float dashDuration;
}