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
            switch (skinModel.type)
            {
                case SkinType.Outfit:
                    outfitSpriteRenderer.sprite = skinModel.skinSprite;
                    break;
                case SkinType.Mouth:
                    mouthSpriteRenderer.sprite = skinModel.skinSprite;
                    break;
                case SkinType.Eyes:
                    eyesSpriteRenderer.sprite = skinModel.skinSprite;
                    break;
                default:
                    Debug.LogWarning($"Unsupported avatar skin type ${skinModel.type}");
                    break;
            }
        }
    }
}