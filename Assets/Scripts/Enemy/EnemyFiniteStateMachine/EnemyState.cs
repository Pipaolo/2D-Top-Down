using UnityEngine;

namespace Enemy.EnemyFiniteStateMachine
{
    public class EnemyState
    {
        protected EnemyStateMachine StateMachine;
        protected Enemy Enemy;
        protected Core.Core Core;
        public float StartTime { get; protected set; }

        public EnemyState(Enemy enemy, EnemyStateMachine stateMachine)
        {
            Enemy = enemy;
            StateMachine = stateMachine;
            Core = enemy.Core;
        }
        
        public virtual void Enter()
        {
            StartTime = Time.time;
            /*startTime = Time.time;
            entity.anim.SetBool(animBoolName, true);*/
            DoChecks();
        }

        public virtual void Exit()
        {
            /*entity.anim.SetBool(animBoolName, false);*/
        }

        public virtual void LogicUpdate()
        {

        }

        public virtual void PhysicsUpdate()
        {
            DoChecks();
        }

        public virtual void DoChecks()
        {

        }
    }
}