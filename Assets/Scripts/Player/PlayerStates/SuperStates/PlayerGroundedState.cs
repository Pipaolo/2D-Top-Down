using Player.PlayerFiniteStateMachine;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player.PlayerStates.SuperStates
{
    public class PlayerGroundedState : PlayerState
    {
        protected int xInput;
        protected int yInput;

        protected Vector2 MousePosition;
        
        public PlayerGroundedState(PlayerFiniteStateMachine.Player player, PlayerStateMachine stateMachine, PlayerData playerData) : base(player, stateMachine, playerData)
        {
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            xInput = Player.InputHandler.NormInputX;
            yInput = Player.InputHandler.NormInputY;
            
            MousePosition = Player.SceneCamera.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            var aimDirection = MousePosition - Player.Rb.position;
            var aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
            Core.Movement.SetRotation(aimAngle);

            
            // Handle player rotation based on mouse position
            
            if (Player.InputHandler.AttackInput)
            {
                StateMachine.UpdateState(Player.AttackState);
            }
            
        }
    }
}