using System.Collections.Generic;
using UnityEngine;

namespace InventorySystem
{
	public class InventoryManager : MonoBehaviour
	{
		[field: SerializeField]
		private InventoryView InventoryView { get; set; }
		
		private List<InventoryObject> Items { get; } = new List<InventoryObject>();

		public void AddItem (InventoryObject item)
		{
			Items.Add(item);
			InventoryView.UpdateInventory(Items);
		}
		
		public void RemoveItem (InventoryObject item)
		{
			Items.Remove(item);
			InventoryView.UpdateInventory(Items);
		}

		public void RemoveAllItems ()
		{
			Items.Clear();
			InventoryView.UpdateInventory(Items);
		}
	}
}