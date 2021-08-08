using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : PlayerInteractState
{

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

        // melee : do dmg in front of some radius
        // range : shoot projectile

        isInteractionDone = true;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicalUpdates()
    {
        base.LogicalUpdates();

        // if clicked object is with tag enemy --> State = Attacking
    }

    public override void PhysicalUpdates()
    {
        base.PhysicalUpdates();
    }
}
