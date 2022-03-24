using Player.PlayerFiniteStateMachine;
using Player.PlayerStates.SuperStates;
using ScriptableObjects.Weapons;
using UnityEngine;
using UnityEngine.InputSystem;
using Weapons;

namespace Player.PlayerStates.SubStates
{
    public class PlayerAttackState :PlayerAbilityState
    {

        private Weapon _weapon;
        
        private int _xInput;
        private int _yInput;
    
        private float _nextAttackTime;
        public PlayerAttackState(PlayerFiniteStateMachine.Player player, PlayerStateMachine stateMachine, PlayerData playerData) : base(player, stateMachine, playerData)
        {
        }

        public override void Enter()
        {
            base.Enter();
            _weapon.EnterWeapon();
            _weapon.ExitWeapon();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            var attackInput = Player.InputHandler.AttackInput;
            _xInput = Player.InputHandler.NormInputX;
            _yInput = Player.InputHandler.NormInputY;
            
            Vector2 mousePosition = Player.SceneCamera.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            var aimDirection = mousePosition - Player.Rb.position;
            var aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
            
            
            Core.Movement.SetVelocityX( PlayerData.movementSpeed * _xInput);
            Core.Movement.SetVelocityY(PlayerData.movementSpeed * _yInput);
            Core.Movement.SetRotation(aimAngle);

            
            if (!attackInput && _xInput == 0)
            {
                StateMachine.UpdateState(Player.IdleState);
                return;
            } else if (!attackInput && (_xInput != 0 || _yInput != 0))
            {
                StateMachine.UpdateState(Player.MoveState);
                return;
            }


            var attackSpeed = PlayerData.attackSpeed;
            
            if (Time.time > _nextAttackTime && _weapon != null)
            {
                var weaponData = _weapon.weaponData;
                if (weaponData.GetType() == typeof(SO_RangeWeaponData))
                {
                    attackSpeed = ((SO_RangeWeaponData) weaponData).shootingSpeed;
                }
                
                _weapon.Attack();
                _nextAttackTime = Time.time + attackSpeed;
            }
            
        }

        public void SetWeapon(Weapon weapon)
        {
            
            _weapon = weapon;
            _weapon.InitializeWeapon(this, Core);
        }
        

        public override void Exit()
        {

            base.Exit();
        }
    }
}