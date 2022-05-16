using System;
using JCI.Core.Events;
using Skintific.Skins;
using UnityEngine;
using UnityEngine.UI;

namespace Skintific.Menu
{
    public class MenuItem : MonoBehaviour
    {
        [SerializeField] private Image icon;
        [SerializeField] private Button button;
        [SerializeField] private GameEventArg changeSkinEvent;
        private SkinModel skinModel;

        public void Set(SkinModel skinModel)
        {
            this.skinModel = skinModel;
            icon.sprite = skinModel.iconSprite;
        }

        private void Awake()
        {
            button.onClick.AddListener(OnClick);
        }

        private void OnDestroy()
        {
            button.onClick.RemoveListener(OnClick);
        }

        private void OnClick()
        {
            if (skinModel == null)
            {
                Debug.LogWarning($"Menu Item hasn't set any skin model yet, cannot request skin change");
                return;
            }
            
            changeSkinEvent.Raise(skinModel);
        }
    }
}