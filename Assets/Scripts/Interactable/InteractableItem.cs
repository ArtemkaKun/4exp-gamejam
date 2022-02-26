using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InventorySystem;

public class InteractableItem : MonoBehaviour
{
    [field: SerializeField]
    private InventoryManager Inventory { get; set; }

    public void TryAddToInventory()
    {
        if (TryGetComponent(out InventoryObject inventoryObject))
        {
            Inventory.AddItem(inventoryObject);
        }
    }
}
