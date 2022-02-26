using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InventorySystem;

public class InteractableItem : MonoBehaviour
{
    [field: SerializeField]
    private InventoryManager Inventory { get; set; }
    [field: SerializeField]
    private InventoryObject InventoryObject { get; set; }

    public void AddToInventory()
    {
        Inventory.AddItem(InventoryObject);
    }
}
