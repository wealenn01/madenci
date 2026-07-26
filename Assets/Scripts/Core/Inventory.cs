using System;
using System.Collections.Generic;
using Madenci.Data;
using UnityEngine;

namespace Madenci.Core
{
    public class Inventory : MonoBehaviour
    {
        readonly Dictionary<OreData, int> _ores = new();

        public event Action Changed;

        public int GetCount(OreData ore)
        {
            if (ore == null) return 0;
            return _ores.TryGetValue(ore, out var n) ? n : 0;
        }

        public void Add(OreData ore, int amount)
        {
            if (ore == null || amount <= 0) return;
            _ores.TryGetValue(ore, out var n);
            _ores[ore] = n + amount;
            Changed?.Invoke();
        }

        public int SellAll(Wallet wallet)
        {
            if (wallet == null) return 0;
            var total = 0;
            foreach (var (ore, count) in _ores)
            {
                if (ore == null || count <= 0) continue;
                total += ore.sellPrice * count;
            }

            if (total <= 0) return 0;
            wallet.Add(total);
            _ores.Clear();
            Changed?.Invoke();
            return total;
        }

        public IEnumerable<KeyValuePair<OreData, int>> Entries => _ores;
    }
}
