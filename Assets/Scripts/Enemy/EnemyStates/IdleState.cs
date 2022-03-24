using System;
using Enemy.Data;
using Enemy.EnemyFiniteStateMachine;
using UnityEngine;
using Random = Unity.Mathematics.Random;

namespace Enemy.EnemyStates
{
    public class IdleState: EnemyState
    {

        protected EnemyIdleStateData StateData;
        protected float IdleTime;
        protected bool IsIdleTimeOver;
        public IdleState(EnemyFiniteStateMachine.Enemy enemy, EnemyStateMachine stateMachine, EnemyIdleStateData stateData) : base(enemy, stateMachine)
        {
            StateData = stateData;
        }

        public override void Enter()
        {
            base.Enter();
            Core.Movement.SetVelocityX(0f);
            IsIdleTimeOver = false;
            SetRandomIdleTime();
        }

        private void SetRandomIdleTime()
        {
            IdleTime = UnityEngine.Random.Range(StateData.minIdleTime, StateData.maxIdleTime);
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            Core.Movement.SetVelocityX(0f);

            if (Time.time >= StartTime + IdleTime)
            {
                IsIdleTimeOver = true;
            }
            
        }
    }
}