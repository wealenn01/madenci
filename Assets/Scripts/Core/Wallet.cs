using System;
using UnityEngine;

namespace Madenci.Core
{
    public class Wallet : MonoBehaviour
    {
        [SerializeField] int money;

        public int Money => money;
        public event Action<int> Changed;

        public void Add(int amount)
        {
            if (amount <= 0) return;
            money += amount;
            Changed?.Invoke(money);
        }

        public bool TrySpend(int amount)
        {
            if (amount <= 0) return true;
            if (money < amount) return false;
            money -= amount;
            Changed?.Invoke(money);
            return true;
        }
    }
}
