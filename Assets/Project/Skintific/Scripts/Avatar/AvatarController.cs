using System;
using Skintific.Skins;
using UnityEngine;

namespace Skintific.Avatar
{
    public class AvatarController : MonoBehaviour
    {
       [SerializeField] private SpriteRenderer outfitSpriteRenderer;
       [SerializeField] private SpriteRenderer mouthSpriteRenderer;
       [SerializeField] private SpriteRenderer eyesSpriteRenderer;

        public void SetSkin(SkinModel skinModel)
        {
            var spriteRenderer = GetSpriteRendererByType(skinModel.type);
            spriteRenderer.sprite = skinModel.skinSprite;
            var spriteRendererTransform = spriteRenderer.transform;
            spriteRendererTransform.localPosition = skinModel.skinOffset;
            spriteRendererTransform.localScale = skinModel.skinScale;
        }

        private SpriteRenderer GetSpriteRendererByType(string type)
        {
            SpriteRenderer spriteRenderer;

            switch (type)
            {
                case SkinType.Outfit:
                    spriteRenderer = outfitSpriteRenderer;
                    break;
                case SkinType.Mouth:
                    spriteRenderer = mouthSpriteRenderer;
                    break;
                case SkinType.Eyes:
                    spriteRenderer = eyesSpriteRenderer;
                    break;
                default:
                    throw new Exception($"Unsupported avatar skin type ${type}");
            }

            return spriteRenderer;
        }
    }
}