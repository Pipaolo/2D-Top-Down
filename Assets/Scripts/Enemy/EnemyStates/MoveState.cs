using Enemy.Data;
using Enemy.EnemyFiniteStateMachine;
using Unity.VisualScripting;
using UnityEngine;

namespace Enemy.EnemyStates
{
    public class MoveState : EnemyState
    {
        protected EnemyMoveStateData StateData;
        protected GameObject PlayerGameObject;
   
        public MoveState(EnemyFiniteStateMachine.Enemy enemy, EnemyStateMachine stateMachine, EnemyMoveStateData stateData) : base(enemy, stateMachine)
        {
            StateData = stateData;
        }

        public override void Enter()
        {
            base.Enter();
            PlayerGameObject = GameObject.FindGameObjectWithTag("Player");
        }
    }
}