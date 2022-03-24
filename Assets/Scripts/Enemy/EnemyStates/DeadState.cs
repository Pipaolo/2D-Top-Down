using Enemy.EnemyFiniteStateMachine;
using UnityEngine;

namespace Enemy.EnemyStates
{
    public class DeadState : EnemyState
    {
        public DeadState(EnemyFiniteStateMachine.Enemy enemy, EnemyStateMachine stateMachine) : base(enemy, stateMachine)
        {
        }

        public override void Enter()
        {
            base.Enter();
            Core.Movement.SetVelocityX(0);
            Core.Movement.SetVelocityY(0);
            Enemy.Dead();
      
        }
        
        
    }
}