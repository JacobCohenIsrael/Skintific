using JCI.Core.Events;
using Skintific.Player;
using Skintific.Skins;
using UnityEngine;

namespace Skintific.Game
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private SkinsConfig skinsConfig;
        [SerializeField] private PlayerModel playerModel;
        [SerializeField] private GameEvent preloadEndedEvent;
        
        private void Start()
        {
            PopulateSkinsConfig();
            InitializePlayer();
            preloadEndedEvent.Raise();
        }

        private void InitializePlayer()
        {
            var userData = UserDataGetter.GetUserData();
            playerModel.level.SetAndNotify(userData.Level);
            playerModel.coins.SetAndNotify(userData.Coins);
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