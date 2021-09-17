using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct PlayerStates
{
    public PlayerIdleState IdleState { get; private set; }
    public PlayerCombatIdleState CombatIdleState { get; private set; }
    public PlayerNoCombatIdleState NoCombatIdleState { get; private set; }

    public PlayerMoveState MoveState { get; private set; }
    public PlayerRunState RunState { get; private set; }
    public PlayerWalkState WalkState { get; private set; }
    
    public PlayerAttackState AttackState { get; private set; }
    public PlayerDashState DashState { get; private set; }
    public PlayerDeadState DeadState { get; private set; }

    public void InitializePlayerStates(PlayerController obj, PlayerStateManager StateManager)
    {
        IdleState = new PlayerIdleState(obj, StateManager, global::PlayerState.State.Idle);
        CombatIdleState = new PlayerCombatIdleState(obj, StateManager, global::PlayerState.State.Idle);
        NoCombatIdleState = new PlayerNoCombatIdleState(obj, StateManager, global::PlayerState.State.Idle);

        MoveState = new PlayerMoveState(obj, StateManager, global::PlayerState.State.Move);
        RunState = new PlayerRunState(obj, StateManager, global::PlayerState.State.Run);
        WalkState = new PlayerWalkState(obj, StateManager, global::PlayerState.State.Walk);

        AttackState = new PlayerAttackState(obj, StateManager, global::PlayerState.State.Attack);
        DashState = new PlayerDashState(obj, StateManager, global::PlayerState.State.Dash);
        DeadState = new PlayerDeadState(obj, StateManager, global::PlayerState.State.Dead);
    }
}