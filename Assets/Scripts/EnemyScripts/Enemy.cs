

public class Enemy : EnemyController
{
    public override void InitializeControllerVars()
    {
        AttackDamage = 10;
        AttackSpeed = 1.7f;
        MovementSpeed = 2f;
        VisionRange = 6f;
        AttackRange = 2f;
    }
}