using System;
using System.Collections.Generic;

namespace Common
{
    public class Inventory
    {
        public int Slots { get; private set; } = 20;
        public List<InventoryItem> items;
        public Inventory()
        {
            items = new List<InventoryItem>();
        }
    }
}
