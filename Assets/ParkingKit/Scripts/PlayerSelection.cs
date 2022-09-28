using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Randoms.ParkingKit
{
    using Internals;
    
    /// <summary>
    /// Player Selection Script
    /// </summary>
    [DisallowMultipleComponent]
    public class PlayerSelection : MonoBehaviour
    {
        public List<PlayerData> players;
        public PlayerUnlockSelection playerUnlockSelection;
        public Transform spawnPoint;
        public Button leftBtn, rightBtn;

        private int currIdx;
        
        private void Awake()
        {
            if (Instance) Destroy(gameObject);
            Instance = this;
            // currIdx = PlayerPrefs.GetInt()
            CreatePool();
            AddListener();
        }
        
        /// <summary>
        /// Creates Player Prefab Pool
        /// </summary>
        private void CreatePool()
        {
            foreach (PlayerData player in players)
            {
                var playerPInstance = Instantiate(player.playerPrefab, spawnPoint.position, spawnPoint.rotation);
                playerPInstance.SetActive(false);
                player.playerPrefab = playerPInstance;
            }
        }
        
        /// <summary>
        /// Add Event listener on buttons
        /// </summary>
        private void AddListener()
        {
            leftBtn.onClick.AddListener(() => {});
            rightBtn.onClick.AddListener(() => {});
        }
        
    #region Instance

        public static PlayerSelection Instance { get; private set; }

        #endregion
        

    }
    
}
