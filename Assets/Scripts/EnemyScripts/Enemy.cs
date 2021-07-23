

public class Enemy : EnemyController
{
    public override void InitializeControllerVars()
    {
        MovementSpeed = 2f;
        VisionRange = 6f;
        AttackRange = 2f;
    }   
}