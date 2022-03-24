using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Managers
{
    public class InputManager : MonoBehaviour
    {
        #region Singleton

        private static InputManager _instance;

        public static InputManager Instance => _instance;
        
        private void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(this.gameObject);
            } else {
                _instance = this;
            }
        }


        #endregion
        public PlayerInput PlayerInput { get; private set; }

        private void Start()
        {
            PlayerInput = GetComponent<PlayerInput>();
        }
    }
}