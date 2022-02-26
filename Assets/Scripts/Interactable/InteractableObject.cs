using InventorySystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractableObject : Interactable
{
    [field: SerializeField]
    public UnityEvent OnPresence { get; private set; }
    [field: SerializeField]
    private Animator Animator { get; set; }
    [field: SerializeField]
    private List<GameObject> InteractableObjectsToSpawnOnPresence { get; set; }

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
        DisableThisObject();
    }

    private void OnPresenceEventHandler()
    {
        PlayOpenAnimation();
        SpawnObjectsOnPresence();
    }

    private void SpawnObjectsOnPresence()
    {
        foreach (GameObject interactable in InteractableObjectsToSpawnOnPresence)
        {
            if (interactable != null)
            {
                interactable.SetActive(true);
            }
        }
    }

    private void PlayOpenAnimation()
    {
        Animator.SetBool("IsOpened", true);
    }
}
