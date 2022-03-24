using System;
using Player.Input;
using UnityEngine;
using Core.CoreComponents;
using Player.PlayerStates.SubStates;

namespace Player.PlayerFiniteStateMachine
{
    public class Player : MonoBehaviour
    {

        #region State Vars

        public PlayerStateMachine StateMachine { get; private set; }    
        
        public PlayerIdleState IdleState { get; private set; }
        public PlayerMoveState MoveState { get; private set; }
        public PlayerAttackState AttackState { get; private set; }
        
        

        #endregion

        [SerializeField]
        private PlayerData playerData;
        
        #region Components

        public Core.Core Core { get; private set; }
        public PlayerInputHandler InputHandler { get; private set; }
        public PlayerInventory Inventory { get; private set; }
        
        public Camera SceneCamera { get; private set; }
        public Rigidbody2D Rb { get; private set; }
        
        #endregion


        #region Unity Callbacks

        private void Awake()
        {
            Core = GetComponentInChildren<Core.Core>();

            StateMachine = new PlayerStateMachine();

            IdleState = new PlayerIdleState(this, StateMachine, playerData);
            MoveState = new PlayerMoveState(this, StateMachine, playerData);
            AttackState = new PlayerAttackState(this, StateMachine, playerData);

        }

        private void Start()
        {
            Rb = GetComponent<Rigidbody2D>();
            InputHandler = GetComponent<PlayerInputHandler>();
            Inventory = GetComponent<PlayerInventory>();
            SceneCamera = Camera.main;
            
            if (Inventory.weapons.Count > 0)
            {
                
                AttackState.SetWeapon(Inventory.weapons[0]);
            }
            StateMachine.Initialize(IdleState);
        }

        private void Update()
        {
            Core.LogicUpdate();
            StateMachine.CurrentState.LogicUpdate();
            
        }

        private void FixedUpdate()
        {
            StateMachine.CurrentState.PhysicsUpdate();
            
        }

        #endregion

    
    }
}