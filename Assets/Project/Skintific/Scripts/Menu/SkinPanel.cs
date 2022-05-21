using Skintific.Player;
using Skintific.Skins;
using UnityEngine;

namespace Skintific.Menu
{
    public class SkinPanel : MonoBehaviour
    {
        [SerializeField] private PlayerModel playerModel;

        private MenuItem activeMenuItem;

        public void CreateAndSetMenuItem(SkinModel skinModel, MenuItem menuItemPrefab)
        {
            var menuItem = Instantiate(menuItemPrefab, transform);
            menuItem.Set(skinModel, playerModel.HasSkin(skinModel.id), playerModel.Level);
            menuItem.OnSelect += OnMenuItemSelected;
        }

        private void OnMenuItemSelected(MenuItem menuItem)
        {
            if (activeMenuItem != null && menuItem != activeMenuItem)
            {
                activeMenuItem.Unselect();
            }
            activeMenuItem = menuItem;
        }
    }
}