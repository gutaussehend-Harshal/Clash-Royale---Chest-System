using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// This class handles player name, no of gems and coins.
/// </summary>
namespace Outscal.ChestRoyalSystem
{
    public class Player : MonoSingleton<Player>
    {
        [Header("Player Scriptable object")]
        [SerializeField] private PlayerScriptableObject playerSO;

        [Header("Text Settings")]
        [SerializeField] private TextMeshProUGUI playerNameText;
        [SerializeField] private TextMeshProUGUI coinsText;
        [SerializeField] private TextMeshProUGUI gemsText;

        [Header("Player Settings")]
        [SerializeField] private string playerName;
        [SerializeField] private int coins;
        [SerializeField] private int gems;

        [HideInInspector]
        private bool sufficientGems;
        private void Start()
        {
            SetPlayerData(playerSO);
            ShowPlayerData();
        }

        // Set Player Data
        private void SetPlayerData(PlayerScriptableObject playerSO)
        {
            playerName = playerSO.playerName;
            // gameObject.name = playerName;
            coins = playerSO.coins;
            gems = playerSO.gems;
        }

        // Show Player data
        private void ShowPlayerData()
        {
            playerNameText.text = "Player : " + playerName;
            coinsText.text = "Coins : " + coins.ToString();
            gemsText.text = "Gems : " + gems.ToString();
        }

        // Add coins and gems
        public void AddToPlayer(int coinsToAdd, int gemsToAdd)
        {
            coins += coinsToAdd;
            gems += gemsToAdd;
        }

        // Remove gems
        public bool RemoveFromPlayer(int gemsToRemove)
        {
            sufficientGems = true;
            if (gems >= gemsToRemove)
            {
                gems -= gemsToRemove;
            }
            else
            {
                sufficientGems = false;
            }
            ShowPlayerData();
            return sufficientGems;
        }
    }
}