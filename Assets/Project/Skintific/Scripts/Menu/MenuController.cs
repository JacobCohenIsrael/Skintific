using JCI.Core.Events;
using Skintific.Player;
using Skintific.Skins;
using UnityEngine;

namespace Skintific.Menu
{
    public class MenuController : MonoBehaviour
    {
        [SerializeField] private SkinsConfig skinsConfig;
        [SerializeField] private PlayerModel playerModel;
        [SerializeField] private GameEvent preloadEndedEvent;

        [SerializeField] private SkinPanel outfitsPanel;
        [SerializeField] private SkinPanel mouthsPanel;
        [SerializeField] private SkinPanel eyesPanel;

        [SerializeField] private MenuItem outfitMenuItemPrefab;
        [SerializeField] private MenuItem mouthMenuItemPrefab;
        [SerializeField] private MenuItem eyesMenuItemPrefab;
        private void Awake()
        {
            preloadEndedEvent.RegisterListener(OnPreloadEnded);
        }

        private void OnPreloadEnded()
        {
            PopulateMenu();
        }

        private void PopulateMenu()
        {
            PopulateOutfits();
            PopulateMouths();
            PopulateEyes();
        }

        private void PopulateEyes()
        {
            foreach (var skinsConfigEye in skinsConfig.Eyes)
            {
                CreateAndSetMenuItem(skinsConfigEye, eyesMenuItemPrefab, eyesPanel.transform);

            }
        }

        private void PopulateMouths()
        {
            foreach (var skinsConfigMouth in skinsConfig.Mouths)
            {
                CreateAndSetMenuItem(skinsConfigMouth, mouthMenuItemPrefab, mouthsPanel.transform);

            }
        }

        private void PopulateOutfits()
        {
            foreach (var skinsConfigOutfit in skinsConfig.Outfits)
            {
                CreateAndSetMenuItem(skinsConfigOutfit, outfitMenuItemPrefab, outfitsPanel.transform);
            }
        }

        private void CreateAndSetMenuItem(SkinModel skinModel, MenuItem menuItemPrefab, Transform panelTransform)
        {
            var menuItem = Instantiate(menuItemPrefab, panelTransform);
            menuItem.Set(skinModel, playerModel.HasSkin(skinModel.id), playerModel.Level);
        }
    }
}