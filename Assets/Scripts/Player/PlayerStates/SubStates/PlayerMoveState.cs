using Player.PlayerFiniteStateMachine;
using Player.PlayerStates.SuperStates;

namespace Player.PlayerStates.SubStates
{
    public class PlayerMoveState :PlayerGroundedState
    {
        public PlayerMoveState(PlayerFiniteStateMachine.Player player, PlayerStateMachine stateMachine, PlayerData playerData) : base(player, stateMachine, playerData)
        {
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            Core.Movement.SetVelocityX(PlayerData.movementSpeed * xInput);
            Core.Movement.SetVelocityY(PlayerData.movementSpeed * yInput);

            if (!IsExitingState)
            {
                if (xInput == 0)
                {
                    StateMachine.UpdateState(Player.IdleState);
                }
            }
        }
    }
}