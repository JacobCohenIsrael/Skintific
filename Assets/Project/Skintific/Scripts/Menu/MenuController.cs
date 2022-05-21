using JCI.Core.Events;
using Skintific.Skins;
using UnityEngine;

namespace Skintific.Menu
{
    [RequireComponent(typeof(Animator))]
    public class MenuController : MonoBehaviour
    {
        [SerializeField] private SkinsConfig skinsConfig;
        [SerializeField] private GameEvent preloadEndedEvent;

        [SerializeField] private SkinPanel outfitsPanel;
        [SerializeField] private SkinPanel mouthsPanel;
        [SerializeField] private SkinPanel eyesPanel;

        [SerializeField] private MenuItem outfitMenuItemPrefab;
        [SerializeField] private MenuItem mouthMenuItemPrefab;
        [SerializeField] private MenuItem eyesMenuItemPrefab;


        [SerializeField] private string entryTrigger = "Entry";
        [SerializeField] private string openState = "OpenState";

        private void Awake()
        {
            preloadEndedEvent.RegisterListener(OnPreloadEnded);
        }

        private void OnPreloadEnded()
        {
            GetComponent<Animator>().TriggerAndWaitForState(entryTrigger, openState)
                .Then(PopulateMenu);
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
                eyesPanel.CreateAndSetMenuItem(skinsConfigEye, eyesMenuItemPrefab);
            }
        }

        private void PopulateMouths()
        {
            foreach (var skinsConfigMouth in skinsConfig.Mouths)
            {
                mouthsPanel.CreateAndSetMenuItem(skinsConfigMouth, mouthMenuItemPrefab);
            }
        }

        private void PopulateOutfits()
        {
            foreach (var skinsConfigOutfit in skinsConfig.Outfits)
            {
                outfitsPanel.CreateAndSetMenuItem(skinsConfigOutfit, outfitMenuItemPrefab);
            }
        }
    }
}