using System;
using Achievement;
using Managers;
using UnityEngine;

namespace Enemy.EnemyFiniteStateMachine
{
    public class Enemy : MonoBehaviour
    {
        protected EnemyStateMachine StateMachine;
        public Core.Core Core { get; private set; }
        

        public virtual void Awake()
        {
            Core = GetComponentInChildren<Core.Core>();
            StateMachine = new EnemyStateMachine();
        }

        public virtual void Update()
        {
            Core.LogicUpdate();
            StateMachine.CurrentState.LogicUpdate();
            
        }

        public virtual void FixedUpdate()
        {
            StateMachine.CurrentState.PhysicsUpdate();
            
        }

        public virtual void Dead()
        {
            Debug.Log("I was killed!");
            GameManager.Instance.IncreaseTotalEnemyDefeated();
            AchievementsManager.Instance.UpdateAchievementProgress(AchievementTypes.KillCount, 1);

            Destroy(gameObject);
        }
    }
}