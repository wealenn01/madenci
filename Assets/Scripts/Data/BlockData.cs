using UnityEngine;

namespace Madenci.Data
{
    [CreateAssetMenu(menuName = "Madenci/Block", fileName = "Block_")]
    public class BlockData : ScriptableObject
    {
        public string displayName = "Toprak";
        [Tooltip("Kazmanın minHardness değeri buna yetmeli")]
        public int hardness = 1;
        public int maxHp = 3;
        public OreData drop;
        public int dropAmount = 1;
        public Color color = new Color(0.45f, 0.32f, 0.2f);
    }
}
