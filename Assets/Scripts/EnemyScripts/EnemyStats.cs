using System;

[Serializable]
public class EnemyStats
{
    public int attackDamage; // depends on the player weapon's damage
    public float attackSpeed;
    public float attackRange;
    public float movementSpeed;
    public float walkingSpeed;
    public float health;
    public int mana; // mana bar for some spells/utilities
    public int armor;
    public float visionRange;
    public EnemyAttackType attackType;
}
