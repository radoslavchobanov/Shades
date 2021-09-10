using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : PlayerInteractState
{
    public PlayerAttackState(PlayerController playerController, PlayerStateManager stateManager, State state)
        : base(playerController, stateManager, state)
    { }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();

        playerController.transform.LookAt(playerController.GetPointerPosByGroundPlane());

        if (Time.time >= playerController.timeForNextAttack) // if the time for next attack has come
        {   
            playerController.Energy.UpdateDegenerate();

            playerController.timeForNextAttack = Time.time + (1 / playerController.AttackSpeed);
            playerController.Animator.SetBool("Shoot", true);

        // Check for the weapon type :
        // - if it is melee -> go to MeleeAttackState
        // - if it is range -> go to RangeAttackState

        // range : shoot projectile
            playerController.Shoot(playerController.BulletPrefab, 
                                    playerController.ShootingStartPoint.transform.position, 
                                    playerController.ShootingStartPoint.transform.localRotation);
        // -----------------------  

        // melee : do dmg in front of some radius
        // --------------------------------------
        }

        isInteractionDone = true;
    }

    public override void Exit()
    {
        base.Exit();
        
        playerController.Animator.SetBool("Shoot", false);
    }

    public override void LogicalUpdates()
    {
        base.LogicalUpdates();
        
        // // ??? Potential FIXME ???
        // if (Time.time - startTime >= 0.16f) // 0.16f is the duration of the animation ?
        // {
        //     isInteractionDone = true;
        // }
        // else playerController.Animator.SetBool("Shoot", false);
    }

    public override void PhysicalUpdates()
    {
        base.PhysicalUpdates();
    }
}
