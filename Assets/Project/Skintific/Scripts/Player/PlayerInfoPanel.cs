using System;
using TMPro;
using UnityEngine;

namespace Skintific.Player
{
    public class PlayerInfoPanel : MonoBehaviour
    {
        [SerializeField] private PlayerModel playerModel;
        [SerializeField] private TextMeshProUGUI levelText;
        [SerializeField] private TextMeshProUGUI coinsText;

        private void Awake()
        {
            playerModel.coins.Updated += UpdateCoins;
            playerModel.playerLevel.Updated += UpdateLevel;
        }

        private void Start()
        {
            UpdateLevel(playerModel.Level);
            UpdateCoins(playerModel.Coins);
        }

        private void OnDestroy()
        {
            playerModel.coins.Updated -= UpdateCoins;
            playerModel.playerLevel.Updated -= UpdateLevel;
        }

        private void UpdateCoins(long coins)
        {
            coinsText.text = coins.ToString("N0");
        }

        private void UpdateLevel(int level)
        {
            levelText.text = level.ToString("N0");
        }
    }
}