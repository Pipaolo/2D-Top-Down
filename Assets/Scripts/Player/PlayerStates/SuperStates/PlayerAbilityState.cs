using Player.PlayerFiniteStateMachine;

namespace Player.PlayerStates.SuperStates
{
    public class PlayerAbilityState :PlayerState
    {
        protected bool IsAbilityDone;
        public PlayerAbilityState(PlayerFiniteStateMachine.Player player, PlayerStateMachine stateMachine, PlayerData playerData) : base(player, stateMachine, playerData)
        {
        }

        public override void DoChecks()
        {
            base.DoChecks();
        }

        public override void Enter()
        {
            base.Enter();
            IsAbilityDone = false;
        }

     
    }
}