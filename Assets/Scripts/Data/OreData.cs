using UnityEngine;

namespace Madenci.Data
{
    [CreateAssetMenu(menuName = "Madenci/Ore", fileName = "Ore_")]
    public class OreData : ScriptableObject
    {
        public string displayName = "Cevher";
        public int sellPrice = 1;
        public Color color = Color.gray;
    }
}
