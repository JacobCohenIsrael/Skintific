using System.Collections.Generic;
using JCI.Core.Models;
using UnityEngine;

namespace Skintific.Player
{
    [CreateAssetMenu(menuName = "Skintific/Player/PlayerModel", fileName = "PlayerModel")]
    public class PlayerModel : ScriptableObject
    {
        [SerializeField] public LongVar coins;
        [SerializeField] public IntVar level;

        private Dictionary<string, bool> ownedSkins = new Dictionary<string, bool>();
        public int Level => level.value;

        public long Coins => coins.value;

        public bool HasSkin(string skinId)
        {
            return ownedSkins.ContainsKey(skinId) && ownedSkins[skinId];
        }

        public void AddSkin(string skinId)
        {
            ownedSkins[skinId] = true;
        }

        public void Notify()
        {
            coins.Notify();;
            level.Notify();
        }
    }
}