using System.Collections.Generic;
using UnityEngine;

namespace Skintific.Skins
{
    [CreateAssetMenu(menuName = "Skintific/Skins/Config", fileName = "SkinsConfig")]
    public class SkinsConfig : ScriptableObject
    {
        public List<SkinModel> Outfits;
        public List<SkinModel> Mouths;
        public List<SkinModel> Eyes;
        
        public void Reset()
        {
            Outfits = new List<SkinModel>();
            Mouths = new List<SkinModel>();
            Eyes = new List<SkinModel>();
        }
    }
}