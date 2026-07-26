using Madenci.Data;
using UnityEngine;

namespace Madenci.World
{
    public class MineableBlock : MonoBehaviour
    {
        public BlockData Data { get; private set; }
        public Vector2Int GridPos { get; private set; }

        int _hp;
        SpriteRenderer _sr;
        WorldGrid _grid;

        public void Setup(BlockData data, Vector2Int gridPos, WorldGrid grid, Sprite sprite)
        {
            Data = data;
            GridPos = gridPos;
            _grid = grid;
            _hp = data.maxHp;
            _sr = gameObject.AddComponent<SpriteRenderer>();
            _sr.sprite = sprite;
            _sr.color = data.color;
            _sr.sortingOrder = 0;
            transform.localScale = Vector3.one * 0.98f;
        }

        public bool TryHit(int damage, int pickaxeHardness, InventoryTarget inventory)
        {
            if (Data == null) return false;
            if (pickaxeHardness < Data.hardness)
            {
                Flash(new Color(1f, 0.35f, 0.35f));
                return false;
            }

            _hp -= Mathf.Max(1, damage);
            Flash(Color.white);

            if (_hp > 0)
            {
                var t = Mathf.Clamp01(_hp / (float)Data.maxHp);
                _sr.color = Color.Lerp(Data.color * 0.55f, Data.color, t);
                return true;
            }

            if (Data.drop != null && inventory != null)
                inventory.ReceiveOre(Data.drop, Data.dropAmount);

            _grid.RemoveBlock(GridPos);
            Destroy(gameObject);
            return true;
        }

        void Flash(Color c)
        {
            if (_sr == null) return;
            _sr.color = c;
        }
    }

    public interface InventoryTarget
    {
        void ReceiveOre(OreData ore, int amount);
    }
}
