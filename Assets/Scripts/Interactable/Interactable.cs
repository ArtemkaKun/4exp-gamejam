using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    [field: SerializeField]
    public UnityEvent OnInteract { get; private set; }
    [field: SerializeField]
    protected List<GameObject> InteractableObjectsToSpawnOnInteract { get; set; }

    protected void SpawnObjectsOnInteract()
    {
        foreach (GameObject interactable in InteractableObjectsToSpawnOnInteract)
        {
            interactable.SetActive(true);
        }
    }

    protected void DisableThisObject()
    {
        gameObject.SetActive(false);
    }
}
