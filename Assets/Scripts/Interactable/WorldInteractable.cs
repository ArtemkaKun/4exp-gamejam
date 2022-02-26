using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using InventorySystem;
using System.Linq;

public class WorldInteractable : Interactable
{
    [field: SerializeField]
    private List<string> RequiredItems { get; set; }
    [field: SerializeField]
    private InventoryManager Inventory { get; set; }

    protected virtual void OnEnable()
    {
        OnInteract.AddListener(OnInteractEventHandler);
    }

    protected virtual void OnDisable()
    {
        OnInteract.RemoveListener(OnInteractEventHandler);
    }

    private void OnInteractEventHandler()
    {
        if (CheckPlayersHasRequiredItems() == true)
        {
            SpawnObjectsOnInteract();
            DisableThisObject();
        }
    }

    private bool CheckPlayersHasRequiredItems()
    {
        foreach (string item in RequiredItems)
        {
            if (Inventory.Items.Find(x => x.Name == item) == null)
            {
                return false;
            }
        }
        return true;
    }
}
