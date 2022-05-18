using DG.Tweening;
using JCI.Core.Events;
using TMPro;
using UnityEngine;

namespace Skintific.Player
{
    public class PlayerInfoPanel : MonoBehaviour
    {
        [SerializeField] private PlayerModel playerModel;
        [SerializeField] private TextMeshProUGUI levelText;
        [SerializeField] private TextMeshProUGUI coinsText;
        [SerializeField] private GameEvent preloadEndedEvent;


        private void Awake()
        {
            playerModel.coins.Updated += UpdateCoins;
            playerModel.level.Updated += UpdateLevel;
            preloadEndedEvent.RegisterListener(OnPreloadEnded);
        }

        private void Start()
        {
            UpdateLevel(playerModel.Level);
            UpdateCoins(playerModel.Coins);
        }

        private void OnDestroy()
        {
            playerModel.coins.Updated -= UpdateCoins;
            playerModel.level.Updated -= UpdateLevel;
            preloadEndedEvent.UnregisterListener(OnPreloadEnded);

        }

        private void OnPreloadEnded()
        {
            GetComponent<RectTransform>().DOAnchorPosY(-15, 1.0f, true);
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