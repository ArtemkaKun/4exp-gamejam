using UnityEngine;

namespace InventorySystem
{
    [System.Serializable]
    public class InventoryObject : MonoBehaviour
    {
        [field: SerializeField]
        public string Name { get; private set; }
        [field: SerializeField]
        public Sprite Icon { get; private set; }
    }
}