using JCI.Core.Events;
using JCI.Core.Extensions;
using Skintific.Player;
using Skintific.Skins;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Skintific.Menu
{
    public class MenuItem : MonoBehaviour
    {
        [SerializeField] private Image icon;
        [SerializeField] private Button button;
        [SerializeField] private GameEventArg changeSkinEvent;
        [SerializeField] private PlayerModel playerModel;
        [SerializeField] private Image minLevelIndicator;
        [SerializeField] private TextMeshProUGUI minLevelText;
        [SerializeField] private Image priceIndicator;
        [SerializeField] private TextMeshProUGUI priceText;
        [SerializeField] private Image lockIndicator;
        
        [SerializeField] private Image backgroundImage;
        [SerializeField] private Color selectedColor;

        public UnityAction<MenuItem> OnSelect;
        
        private SkinModel skinModel;
        private Color originalBackgroundColor;
        
        public void Set(SkinModel skinModel, bool isOwned, int playerLevel)
        {
            this.skinModel = skinModel;
            icon.sprite = skinModel.iconSprite;

            SetIndicators(isOwned, playerLevel);
        }
        
        public void Unselect()
        {
            backgroundImage.color = originalBackgroundColor;
        }

        private void SetIndicators(bool isOwned, int playerLevel)
        {
            if (playerLevel < skinModel.minimumLevel)
            {
                lockIndicator.SetActive(true);
                minLevelIndicator.SetActive(true);
                priceIndicator.SetActive(false);
                minLevelText.text = $"Level {skinModel.minimumLevel}";
            }
            else if (!isOwned && skinModel.price > 0)
            {
                lockIndicator.SetActive(true);
                minLevelIndicator.SetActive(false);
                priceIndicator.SetActive(true);
                priceText.text = skinModel.price.ToString("N0");
            }
            else
            {
                lockIndicator.SetActive(false);
                minLevelIndicator.SetActive(false);
                priceIndicator.SetActive(false);
            }
        }

        private void Awake()
        {
            originalBackgroundColor = backgroundImage.color;
            button.onClick.AddListener(OnClick);
            playerModel.level.Updated += OnLevelUpdate;
        }

        private void OnDestroy()
        {
            button.onClick.RemoveListener(OnClick);
            playerModel.level.Updated -= OnLevelUpdate;
        }

        private void OnLevelUpdate(int obj)
        {
            SetIndicators(playerModel.HasSkin(skinModel.id), playerModel.Level);
        }

        private void OnClick()
        {
            if (skinModel == null)
            {
                Debug.LogWarning("Menu Item hasn't set any skin model yet, cannot request skin change");
                return;
            }
            
            ChangeSkin(skinModel);
            SetIndicators(playerModel.HasSkin(skinModel.id), playerModel.Level);
        }
        
        
        private void ChangeSkin(SkinModel skinModel)
        {
            //TODO: move logic to Item Store Service of some sort. This is not the responsibility of the menu item.
            
            if (skinModel.minimumLevel > playerModel.Level)
            {
                Debug.Log($"Player hasn't reached required level for skin {skinModel.id}");
                return; // TODO: create a message in the UI showing the required level
            }

            var ownSkin = playerModel.HasSkin(skinModel.id);
            if (!ownSkin && skinModel.price > playerModel.coins)
            {
                Debug.Log($"Insufficient coins for skin {skinModel.id}");
                return;
            }

            if (!ownSkin && playerModel.coins >= skinModel.price)
            {
                playerModel.coins.SetAndNotify(playerModel.Coins - skinModel.price);
                playerModel.AddSkin(skinModel.id);
            }
            
            changeSkinEvent.Raise(skinModel);
            backgroundImage.color = selectedColor;
            OnSelect.Invoke(this);
        }
    }
}