using System;
using System.Collections;
using System.Collections.Generic;
using Managers;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class UIInputHandler : MonoBehaviour
{
   private UIManager _uiManager;
   private PlayerInput _playerInput;
   
   public bool ShowSelectionMenu { get; private set; }


   private void Awake()
   {
      ShowSelectionMenu = false;
   }

   private void Start()
   {
      _uiManager = UIManager.Instance;
      _playerInput = InputManager.Instance.PlayerInput;
      
      _playerInput.actions["Esc"].performed += OnShowSelectionMenuInput;
      _playerInput.actions["Esc"].canceled += OnShowSelectionMenuInput;
      _playerInput.actions["Esc"].started += OnShowSelectionMenuInput;
   }
   

   private void OnDisable()
   {
      _playerInput.actions["Esc"].performed -= OnShowSelectionMenuInput;
      _playerInput.actions["Esc"].canceled -= OnShowSelectionMenuInput;
      _playerInput.actions["Esc"].started -= OnShowSelectionMenuInput;
   }

   private void OnShowSelectionMenuInput(InputAction.CallbackContext context)
   {
      if (context.started)
      {
         ShowSelectionMenu = !ShowSelectionMenu;
         UIManager.Instance.ToggleClassSelectionMenu(ShowSelectionMenu);
      }
    
   }
}
