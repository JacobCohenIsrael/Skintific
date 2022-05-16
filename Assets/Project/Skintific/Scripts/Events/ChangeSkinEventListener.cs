using JCI.Core.Events;
using Skintific.Skins;
using UnityEngine.Events;

namespace Skintific.Events
{
    public class ChangeSkinEventListener: GameEventArgListener<SkinModel>
    {
        
        public UnityEventInt Response;

        protected override void Invoke(SkinModel skinModel)
        {
            Response.Invoke(skinModel);
        }
    }
    
    [System.Serializable]
    public class UnityEventInt : UnityEvent<SkinModel>
    {
        
    }
}