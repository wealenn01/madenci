using UnityEngine;

namespace Madenci.Data
{
    [CreateAssetMenu(menuName = "Madenci/Pickaxe", fileName = "Pickaxe_")]
    public class PickaxeData : ScriptableObject
    {
        public string displayName = "Tahta Kazma";
        public int damage = 1;
        [Tooltip("Bu değere kadar sertlikteki blokları kırabilir")]
        public int maxHardness = 1;
        public float swingCooldown = 0.35f;
        public int buyPrice = 0;
        public Color handleColor = new Color(0.55f, 0.35f, 0.15f);
    }
}
