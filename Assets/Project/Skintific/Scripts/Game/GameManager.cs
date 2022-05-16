using JCI.Core.Events;
using JCI.Core.Models;
using Skintific.Player;
using Skintific.Skins;
using UnityEngine;

namespace Project.Skintific.Scripts.Game
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private SkinsConfig skinsConfig;
        [SerializeField] private LongVar playerCoins;
        [SerializeField] private IntVar playerLevel;
        [SerializeField] private GameEvent preloadEndedEvent;
        private void Awake()
        {
            PopulateSkinsConfig();
            InitializePlayer();
            preloadEndedEvent.Raise();
        }

        private void InitializePlayer()
        {
            var userData = UserDataGetter.GetUserData();
            playerLevel.SetValue(userData.Level);
            playerCoins.SetValue(userData.Coins);
        }

        private void PopulateSkinsConfig()
        {
            skinsConfig.Reset();
            var skinModels = SkinsAssetLoader.LoadSkins();
            foreach (var skinModel in skinModels)
            {
                switch (skinModel.type)
                {
                    case SkinType.Outfit:
                        skinsConfig.Outfits.Add(skinModel);
                        break;
                    case SkinType.Mouth:
                        skinsConfig.Mouths.Add(skinModel);
                        break;
                    case SkinType.Eyes:
                        skinsConfig.Eyes.Add(skinModel);
                        break;
                    default:
                        Debug.LogWarning($"Unknown skin model type ${skinModel.type}");
                        break;
                }
            }
        }
    }
}