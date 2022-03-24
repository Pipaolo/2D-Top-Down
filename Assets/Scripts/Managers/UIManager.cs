using System;
using System.Collections.Generic;
using Player;
using UnityEngine;
using UnityEngine.UIElements;

namespace Managers
{
    public class UIManager : MonoBehaviour
    {

        #region Singleton

        private static UIManager _instance;

        public static UIManager Instance => _instance;
        
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
        
        public UIDocument rootDocument;
        private VisualElement _classSelectionMenu;
        private VisualElement _inGameUI;

        public ListView AchievementsListView { get; private set; }


        private TextElement _defeatedEnemiesText;

        private Button _scoutClassButton;
        private Button _scadooshClassButton;
        private Button _sniperClassButton;

        private UIInputHandler _inputHandler;
        
        private void Start()
        {
            _inputHandler = GetComponent<UIInputHandler>();
            
            var root = rootDocument.rootVisualElement;

            _classSelectionMenu = root.Q<VisualElement>("ClassSelectionMenu");
            _inGameUI = root.Q<VisualElement>("InGameUI");
            _defeatedEnemiesText = root.Q<TextElement>("DefeatedEnemiesText");
            
            AchievementsListView = root.Q<ListView>("AchievementsList");
            
            _scoutClassButton = root.Q<Button>("ScoutBtn");
            _scadooshClassButton = root.Q<Button>("ScadooshBtn");
            _sniperClassButton = root.Q<Button>("SniperistBtn");

            _scoutClassButton.clicked += () => OnPlayerClassPressed(PlayerClass.Scout);
            _scadooshClassButton.clicked += () => OnPlayerClassPressed(PlayerClass.Scadoosh);
            _sniperClassButton.clicked += () => OnPlayerClassPressed(PlayerClass.Sniperist);

        }

        
        
        
        private void OnPlayerClassPressed(PlayerClass playerClass)
        {
            _classSelectionMenu.visible = false;
            GameManager.Instance.OnPlayerClassPressed(playerClass);
        }



        public void UpdateDefeatedEnemiesText(string text)
        {
            _defeatedEnemiesText.text = text;
        }

        public void ToggleInGameUI(bool showInGameUI)
        {
            _inGameUI.visible = showInGameUI;
        }
        public void ToggleClassSelectionMenu(bool showSelectionMenu)
        {
            if (!GameManager.Instance.GameStarted)
            {
                return;
            }
            
            _classSelectionMenu.visible = showSelectionMenu;
        }
        
    }
}