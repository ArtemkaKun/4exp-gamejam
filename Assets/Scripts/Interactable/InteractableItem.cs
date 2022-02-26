using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InventorySystem;

public class InteractableItem : MonoBehaviour
{
	[field: SerializeField]
    private InventoryObject InventoryObject { get; set; }

    public void AddToInventory()
    {
	    InventoryManager.Instance.AddItem(InventoryObject);
    }
}
