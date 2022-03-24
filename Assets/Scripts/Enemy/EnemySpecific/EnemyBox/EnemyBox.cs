using System;
using Enemy.Data;
using UnityEngine;

namespace Enemy.EnemySpecific.EnemyBox
{
    public class EnemyBox :EnemyFiniteStateMachine.Enemy
    {
        public EB_MoveState MoveState { get; private set; } 
        public EB_IdleState IdleState { get; private set; }
        public EB_DeadState DeadState { get; private set; }

        [SerializeField]
        private EnemyIdleStateData idleStateData;

        [SerializeField]
        private EnemyMoveStateData moveStateData;

        public override void Awake()
        {
            base.Awake();
            MoveState = new EB_MoveState(this, StateMachine, moveStateData, this);
            IdleState = new EB_IdleState(this, StateMachine, idleStateData, this);
            DeadState = new EB_DeadState(this, StateMachine);
        }

        private void Start()
        {
            StateMachine.Initialize(IdleState);
        }
        
        
    }
}