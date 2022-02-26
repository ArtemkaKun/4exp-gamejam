using InventorySystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractableObject : MonoBehaviour
{
    [field: SerializeField]
    public UnityEvent OnInteract { get; private set; }
    [field: SerializeField]
    public UnityEvent OnPresence { get; private set; }
    [field: SerializeField]
    private Animator Animator { get; set; }
    [field: SerializeField]
    private List<GameObject> InteractableObjectsToSpawnOnInteract { get; set; }
    [field: SerializeField]
    private List<GameObject> InteractableObjectsToSpawnOnPresence { get; set; }
	[field: SerializeField]
	private InventoryManager Inventory { get; set; }

    protected virtual void OnEnable()
    {
        OnInteract.AddListener(OnInteractEventHandler);
        OnPresence.AddListener(OnPresenceEventHandler);
    }

    protected virtual void OnDisable()
    {
        OnInteract.RemoveListener(OnInteractEventHandler);
        OnPresence.RemoveListener(OnPresenceEventHandler);
    }

    private void OnInteractEventHandler()
    {
        SpawnObjectsOnInteract();
		TryAddToInventory();
        DestroyThisObject();
    }

    private void OnPresenceEventHandler()
    {
        PlayOpenAnimation();
        SpawnObjectsOnPresence();
    }

    private void SpawnObjectsOnInteract()
    {
        foreach (GameObject interactable in InteractableObjectsToSpawnOnInteract)
        {
            interactable.SetActive(true);
        }
    }

	private void TryAddToInventory ()
	{
		if (TryGetComponent(out InventoryObject inventoryObject))
		{
			Inventory.AddItem(inventoryObject);
		}
	}

    private void SpawnObjectsOnPresence()
    {
        foreach (GameObject interactable in InteractableObjectsToSpawnOnPresence)
        {
            interactable.SetActive(true);
        }
    }

    private void DestroyThisObject()
    {
        Destroy(gameObject);
    }

    private void PlayOpenAnimation()
    {
        Animator.SetBool("IsOpened", true);
    }
}
