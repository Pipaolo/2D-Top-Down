using Enemy.Data;
using Enemy.EnemyFiniteStateMachine;
using Enemy.EnemyStates;

namespace Enemy.EnemySpecific.EnemyBox
{
    public class EB_IdleState : IdleState
    {
        private EnemyBox _enemyBox;
        public EB_IdleState(EnemyFiniteStateMachine.Enemy enemy, EnemyStateMachine stateMachine, EnemyIdleStateData stateData, EnemyBox enemyBox) : base(enemy, stateMachine, stateData)
        {
            _enemyBox = enemyBox;
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            if (IsIdleTimeOver)
            {
                StateMachine.UpdateState(_enemyBox.MoveState);
            }
        }
    }
}