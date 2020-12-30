using System;
using System.Collections.Generic;
using System.Linq;

namespace Encapsulation
{
    public class Bag
    {
        private readonly List<Item> _items = null;
        private readonly int _maxWeight = 0;

        public Bag(int maxWeight)
        {
            if (maxWeight < 0)
                throw new ArgumentOutOfRangeException();

            _maxWeight = maxWeight;
            _items = new List<Item>(maxWeight);
        }

        public void AddItem(string name, int count)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException($"Item name can't be null, empty or white space.", nameof(name));

            if (count < 1)
                throw new ArgumentOutOfRangeException($"Count of items can't be less than 1.", nameof(count));
            
            var currentWeight = _items.Sum(item => item.Count);
            
            if (currentWeight + count > _maxWeight)
                throw new InvalidOperationException();
            
            var targetItem = _items.FirstOrDefault(item => item.Name == name);

            if (targetItem == null)
            {
                targetItem = new Item(name, count);
                _items.Add(targetItem);
            }
            else
            {
                var indexOf = _items.IndexOf(targetItem);
                var newItem = new Item(name, count);
                _items[indexOf] = newItem;
            }
        }
    }

    public class Item
    {
        private readonly int _count;
        private readonly string _name;
        
        public int Count => _count;
        public string Name => _name;

        public Item(string name, int count)
        {
            _name = name;
            _count = count;
        }
    }
}