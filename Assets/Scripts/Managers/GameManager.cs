using System;
using System.Collections.Generic;
using System.Linq;
using Cinemachine;
using Player;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using Player.PlayerFiniteStateMachine;
using UnityEngine;
using Weapons;

namespace Managers
{

    [Serializable]
    public struct PlayerClassItem
    {
        public PlayerClass PlayerClass;
        public GameObject PlayerPrefab;

    }
    public class GameManager : MonoBehaviour
    {

        #region Singleton

        private static GameManager _instance;

        public static GameManager Instance { get { return _instance; } }

        
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


        private int TotalEnemyDefeated { get; set; }
        
        public bool GameStarted { get; private set; }

        [SerializeField]
        private Transform respawnPoint;


        [SerializeField]
        private CinemachineVirtualCamera cinemachineVirtualCamera;

  
        
        [SerializeField]
        private PlayerClassItem[] playerClasses;

        private PlayerClass _playerClass;

        private GameObject _player;
        
        private void SpawnPlayer()
        {   
            var selectedPlayer = playerClasses.FirstOrDefault(playerItem => playerItem.PlayerClass == _playerClass);
            
            /*
             * If there is an existing player remove it from the scene.
             * then create a spawn a new instance
             */
            if (_player != null)
            {
                SpawnManager.Instance.Reset();
                Destroy(_player);
            }
            
           _player = Instantiate(selectedPlayer.PlayerPrefab);
           _player.transform.position = respawnPoint.position;
            cinemachineVirtualCamera.m_Follow = _player.transform;
            
            UIManager.Instance.ToggleInGameUI(true);
            SpawnManager.Instance.StartSpawner();
            
            GameStarted = true;
        }

        public void IncreaseTotalEnemyDefeated()
        {
            TotalEnemyDefeated++;
        }

        private void Update()
        {
            UIManager.Instance.UpdateDefeatedEnemiesText($"Enemies Defeated: {TotalEnemyDefeated}");
        }
        
        public void OnPlayerClassPressed(PlayerClass playerClass)
        {
            _playerClass = playerClass;
            SpawnPlayer();
        }
    }
}