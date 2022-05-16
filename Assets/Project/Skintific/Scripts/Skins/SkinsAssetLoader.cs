using System.Collections.Generic;
using UnityEngine;

namespace Skintific.Skins
{
    public static class SkinsAssetLoader
    {
        private const string OutfitsPath = "Models/Outfits";
        private const string MouthsPath = "Models/Mouths";
        private const string EyesPath = "Models/Eyes";
        
        public static List<SkinModel> LoadSkins()
        {
            var outfits = Resources.LoadAll<SkinModel>(OutfitsPath);
            var mouths = Resources.LoadAll<SkinModel>(MouthsPath);
            var eyes = Resources.LoadAll<SkinModel>(EyesPath);

            var skinModels = new List<SkinModel>(outfits);
            skinModels.AddRange(mouths);
            skinModels.AddRange(eyes);
            return skinModels;
        }
    }
}