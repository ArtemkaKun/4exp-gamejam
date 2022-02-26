using UnityEngine;

namespace InventorySystem
{
	public class InventoryObject : MonoBehaviour
	{
		[field: SerializeField]
		public string Name { get; private set; }
		[field: SerializeField]
		public Sprite Icon { get; private set; }
	}
}