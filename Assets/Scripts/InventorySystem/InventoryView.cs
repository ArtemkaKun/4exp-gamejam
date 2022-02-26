using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace InventorySystem
{
    public class InventoryView : MonoBehaviour
    {
        [field: SerializeField]
        private GameObject ItemsHolder { get; set; }

        public void UpdateInventory(List<InventoryObject> actualInventory)
        {

        }

        public void AddInventoryItem(InventoryObject inventoryObject)
        {
            GameObject item = new GameObject();
            Image itemImage = item.AddComponent<Image>();
            itemImage.sprite = inventoryObject.Icon;
            item.GetComponent<RectTransform>().SetParent(ItemsHolder.transform);
            item.SetActive(true);
        }
    }
}