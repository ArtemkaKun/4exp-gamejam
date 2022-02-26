using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractableObject : MonoBehaviour
{
    [field: SerializeField]
    public UnityEvent OnInteract { get; private set; }
    [field: SerializeField]
    private GameObject ObjectToDisplay { get; set; }
    [field: SerializeField]
    private List<GameObject> InteractableObjectsToSpawn { get; set; }

    public void PlayOpenAnimation(bool isPlaying)
    {
        Debug.Log(isPlaying ? "gramnko" : " nie");
    }

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
        SpawnObjects();
        DestroyThisObject();
    }

    private void SpawnObjects()
    {
        foreach (GameObject interactable in InteractableObjectsToSpawn)
        {
            interactable.SetActive(true);
        }
    }

    private void DestroyThisObject()
    {
        Destroy(gameObject);
    }
}
