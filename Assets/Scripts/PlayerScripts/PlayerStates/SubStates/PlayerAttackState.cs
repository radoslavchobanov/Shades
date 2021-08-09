using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : PlayerInteractState
{
    public GameObject projectile;
    public float launchVelocity;


    public PlayerAttackState(PlayerController playerController, PlayerStateMachine stateMachine, State state)
        : base(playerController, stateMachine, state)
    { }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();

        playerController.transform.LookAt(playerController.GetPointerPosByGroundPlane());

        playerController.Animator.SetBool("Shoot", true);

        // melee : do dmg in front of some radius
        // range : shoot projectile

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
}
