using UnityEngine;

namespace Player.PlayerFiniteStateMachine
{
    public class PlayerState
    {
        protected Core.Core Core;
        protected Player Player;
        protected PlayerStateMachine StateMachine;
        protected PlayerData PlayerData;

        protected bool IsAnimationFinished;
        protected bool IsExitingState;
        protected float StartTime;


        public PlayerState(Player player, PlayerStateMachine stateMachine, PlayerData playerData)
        {
            this.Player = player;
            this.StateMachine = stateMachine;
            this.PlayerData = playerData;
            Core = player.Core;
        }

        public virtual void Enter()
        {
            DoChecks();
            StartTime = Time.time;
            IsAnimationFinished = false;
            IsExitingState = false;
        }

        public virtual void Exit()
        {
            IsExitingState = true;
        }

        public virtual void LogicUpdate()
        {

        }

        public virtual void PhysicsUpdate()
        {
            DoChecks();
        }

        public virtual void DoChecks() { }

        public virtual void AnimationTrigger() { }

        public virtual void AnimationFinishTrigger() => IsAnimationFinished = true;
    }
}