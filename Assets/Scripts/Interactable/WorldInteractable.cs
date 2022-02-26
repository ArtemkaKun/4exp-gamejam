using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using InventorySystem;
using System.Linq;

public class WorldInteractable : MonoBehaviour
{
    [field: SerializeField]
    public UnityEvent OnInteract { get; private set; }
    [field: SerializeField]
    private List<GameObject> InteractableObjectsToSpawnOnInteract { get; set; }
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
            DestroyThisObject();
        }
    }

    private void SpawnObjectsOnInteract()
    {
        foreach (GameObject interactable in InteractableObjectsToSpawnOnInteract)
        {
            interactable.SetActive(true);
        }
    }

    private void DestroyThisObject()
    {
        Destroy(gameObject);
    }

    private bool CheckPlayersHasRequiredItems()
    {
        foreach (string item in RequiredItems)
        {
            //Debug.Log(Inventory.Items.Find(x => x.Name == item).name);
            if (Inventory.Items.Find(x => x.Name == item) == null)
            {
                return false;
            }
        }
        return true;
    }
}
