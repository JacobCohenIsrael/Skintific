using UnityEngine;
using UnityEngine.UI;

namespace Skintific.Menu
{
    public class MenuItem : MonoBehaviour
    {
        [SerializeField] private Image icon;

        public void Set(Sprite iconSprite)
        {
            icon.sprite = iconSprite;
        }
    }
}