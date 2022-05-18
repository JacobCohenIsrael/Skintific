using JCI.Core.Inspector;
using UnityEngine;

namespace Skintific.Skins
{
    [CreateAssetMenu(menuName = "Skintific/Skins/Skin")]
    public class SkinModel : ScriptableObject
    {
        public string id;
        public int minimumLevel = 1;
        public long price = 0; //TODO: change to work with currencies
        
        [StringInList(typeof(SkinType))]
        public string type;
        public Sprite iconSprite;
        public Sprite skinSprite;
        public Vector3 skinOffset = Vector3.zero;
        public Vector3 skinScale = Vector3.one;
    }
}