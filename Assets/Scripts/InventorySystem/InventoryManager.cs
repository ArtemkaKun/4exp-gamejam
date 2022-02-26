using System.Collections.Generic;
using UnityEngine;

namespace InventorySystem
{
	public class InventoryManager : MonoBehaviour
	{
		private List<InventoryObject> Items { get; } = new List<InventoryObject>();

		public void AddItem (InventoryObject item)
		{
			Items.Add(item);
		}
		
		public void RemoveItem (InventoryObject item)
		{
			Items.Remove(item);
		}

		public void RemoveAllItems ()
		{
			Items.Clear();
		}
	}
}