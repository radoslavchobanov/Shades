using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : PlayerGroundState
{
    float attackDuration;

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

        attackDuration = playerController.GetAnimationClipByName("Armature|03 Shoot").length;
    }

    public override void Exit()
    {
        base.Exit();

        playerController.Animator.SetBool("Shoot", false);
    }

    public override void LogicalUpdates()
    {
        base.LogicalUpdates();
        
        if (!playerController.InputHandler.AttackInput && Time.time - startTime >= attackDuration)
        {
            attacking = false;
            stateManager.ChangeState(playerController.IdleState);
        }
        
        if (playerController.InputHandler.AttackInput)
        {
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
        }
    }

    public override void PhysicalUpdates()
    {
        base.PhysicalUpdates();

        var moveDirection = new Vector3(moveInput.y, 0f, -moveInput.x);

        playerController.Move(moveDirection, playerController.RunSpeed);
    }

    public override void AnimationUpdates()
    {
        base.AnimationUpdates();

        playerController.Animator.SetBool("Shoot", true);
    }
}
