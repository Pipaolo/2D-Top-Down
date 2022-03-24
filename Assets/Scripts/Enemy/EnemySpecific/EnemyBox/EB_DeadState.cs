using Enemy.EnemyFiniteStateMachine;
using Enemy.EnemyStates;

namespace Enemy.EnemySpecific.EnemyBox
{
    public class EB_DeadState : DeadState
    {
        public EB_DeadState(EnemyFiniteStateMachine.Enemy enemy, EnemyStateMachine stateMachine) : base(enemy, stateMachine)
        {
            
        }

        public override void Enter()
        {
            base.Enter();
        }
    }
}