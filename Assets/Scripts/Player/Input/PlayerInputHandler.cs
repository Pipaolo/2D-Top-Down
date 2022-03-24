using Achievement;
using Managers;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player.Input
{
    public class PlayerInputHandler : MonoBehaviour
    {
        private PlayerInput _playerInput;
        private AchievementsManager _achievementsManager;
        private Vector2 RawMovementInput { get; set; }
        public bool AttackInput { get; private set; }
        public int NormInputX { get; private set; } 
        public int NormInputY { get; private set; }


        private void Start()
        {
            _playerInput = InputManager.Instance.PlayerInput;
            _achievementsManager = AchievementsManager.Instance;
                
            _playerInput.actions["Movement"].performed += OnMoveInput;
            _playerInput.actions["Movement"].started += OnMoveInput;
            _playerInput.actions["Movement"].canceled += OnMoveInput;
            
            _playerInput.actions["Combat"].performed += OnAttackInput;
            _playerInput.actions["Combat"].started += OnAttackInput;
            _playerInput.actions["Combat"].canceled += OnAttackInput;
            

        }

        private void OnDisable()
        {
            _playerInput.actions["Movement"].performed -= OnMoveInput;
            _playerInput.actions["Movement"].started -= OnMoveInput;
            _playerInput.actions["Movement"].canceled -= OnMoveInput;

            _playerInput.actions["Combat"].performed -= OnAttackInput;
            _playerInput.actions["Combat"].started -= OnAttackInput;
            _playerInput.actions["Combat"].canceled -= OnAttackInput;
        }


        private void OnMoveInput(InputAction.CallbackContext context)
        {
            _achievementsManager.UpdateAchievementProgress(AchievementTypes.ButtonPress, 1);
            RawMovementInput = context.ReadValue<Vector2>();
            NormInputX = Mathf.RoundToInt(RawMovementInput.x);
            NormInputY = Mathf.RoundToInt(RawMovementInput.y);
        }

        private void OnAttackInput(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                _achievementsManager.UpdateAchievementProgress(AchievementTypes.ButtonPress, 1);
                AttackInput = true;
            } else if (context.canceled)
            {
                AttackInput = false;
            }
            
        }
    }
}