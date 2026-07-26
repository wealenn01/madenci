using Madenci.Core;
using Madenci.Data;
using UnityEngine;

namespace Madenci.Core
{
    public class PlayerProgress : MonoBehaviour
    {
        [SerializeField] PickaxeData startingPickaxe;
        [SerializeField] PickaxeData currentPickaxe;

        public PickaxeData CurrentPickaxe => currentPickaxe;

        public void Init(PickaxeData start)
        {
            startingPickaxe = start;
            currentPickaxe = start;
        }

        public bool TryBuyPickaxe(PickaxeData next, Wallet wallet)
        {
            if (next == null || wallet == null) return false;
            if (currentPickaxe == next) return false;
            if (!wallet.TrySpend(next.buyPrice)) return false;
            currentPickaxe = next;
            return true;
        }
    }
}
