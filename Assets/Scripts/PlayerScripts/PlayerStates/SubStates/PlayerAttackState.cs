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

        playerController.transform.LookAt(GameStateManager.singleton.
                                        GetPointerPosByGroundPlane(playerController.gameObject));

        if (playerController.CanAttack()) // if the time for next attack has come
        {   
        // Check for the weapon type :
        // - if it is melee -> go to MeleeAttackState
        // - if it is range -> go to RangeAttackState

        // range : shoot projectile
            playerController.Shoot();
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
    }

    public override void PhysicalUpdates()
    {
        base.PhysicalUpdates();
    }

    public override void AnimationUpdates()
    {
        base.AnimationUpdates();
        
        playerController.Animator.SetBool("Shoot", true);
    }
}
