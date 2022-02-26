using System.Collections.Generic;
using UnityEngine;

namespace InventorySystem
{
    public class InventoryManager : MonoBehaviour
    {
        [field: SerializeField]
        public List<InventoryObject> Items { get; private set; } = new List<InventoryObject>();
        [field: SerializeField]
        private InventoryView InventoryView { get; set; }

        public void AddItem(InventoryObject item)
        {
            Items.Add(item);
            InventoryView.AddInventoryItem(item);
        }

        public void RemoveItem(InventoryObject item)
        {
            Items.Remove(item);
            InventoryView.UpdateInventory(Items);
        }

        public void RemoveAllItems()
        {
            Items.Clear();
            InventoryView.UpdateInventory(Items);
        }
    }
}