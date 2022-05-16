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


        private void Start()
        {
            levelText.text = playerModel.Level.ToString("N0");
            coinsText.text = playerModel.Coins.ToString("N0");
        }
    }
}