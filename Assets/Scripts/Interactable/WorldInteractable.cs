using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using InventorySystem;
using System.Linq;
using HighlightPlus;

public class WorldInteractable : Interactable
{
    [field: SerializeField]
    private List<string> RequiredItems { get; set; }
    [field: SerializeField]
    private HighlightEffect Highlight { get; set; }

    protected virtual void OnEnable()
    {
        OnInteract.AddListener(OnInteractEventHandler);
    }

    protected virtual void Update()
    {
        if (Highlight.highlighted == true)
        {
            Highlight.outlineColor = CheckPlayersHasRequiredItems() == true ? Color.green : Color.red;
        }
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
            if (InventoryManager.Instance.Items.Find(x => x.Name == item) == null)
            {
                return false;
            }
        }
        return true;
    }
}
