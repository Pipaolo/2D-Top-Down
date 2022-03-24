using Enemy.Data;
using Enemy.EnemyFiniteStateMachine;
using Enemy.EnemyStates;
using UnityEngine;

namespace Enemy.EnemySpecific.EnemyBox
{
    public class EB_MoveState : MoveState
    {
        private EnemyBox _enemyBox;
        public EB_MoveState(EnemyFiniteStateMachine.Enemy enemy, EnemyStateMachine stateMachine, EnemyMoveStateData stateData, EnemyBox enemyBox) : base(enemy, stateMachine, stateData)
        {
            _enemyBox = enemyBox;
        }

        public override void Enter()
        {
            base.Enter();
            
            
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            
            if (PlayerGameObject == null) return;
            
            var currentPosition = _enemyBox.transform.position;
            _enemyBox.transform.position = Vector2.MoveTowards(currentPosition, PlayerGameObject.transform.position,
                StateData.movementSpeed * Time.deltaTime);
            
            if (Core.Stats.IsDead())
            {
                StateMachine.UpdateState(_enemyBox.DeadState);
            }
            
        }
    }
}