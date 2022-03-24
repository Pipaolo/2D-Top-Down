using UnityEngine;

namespace Player.PlayerFiniteStateMachine
{
    public class PlayerStateMachine
    {
        public PlayerState CurrentState { get; private set; }

        public void Initialize(PlayerState state)
        {
            CurrentState = state;
            CurrentState.Enter();
        }

        public void UpdateState(PlayerState state)
        {
            CurrentState.Exit();
            CurrentState = state;
            CurrentState.Enter();
        }
        
    }
}