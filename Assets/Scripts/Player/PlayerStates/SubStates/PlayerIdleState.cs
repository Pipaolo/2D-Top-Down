using Player.PlayerFiniteStateMachine;
using Player.PlayerStates.SuperStates;
using UnityEngine;

namespace Player.PlayerStates.SubStates
{
    public class PlayerIdleState : PlayerGroundedState
    {
        public PlayerIdleState(PlayerFiniteStateMachine.Player player, PlayerStateMachine stateMachine, PlayerData playerData) : base(player, stateMachine, playerData)
        {
        }

        public override void Enter()
        {
            base.Enter();
            Core.Movement.SetVelocityX(0f);
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            if (!IsExitingState)
            {
                if (xInput != 0 || yInput != 0)
                {
                    StateMachine.UpdateState(Player.MoveState);
                }
                
            }
        }
    }
}