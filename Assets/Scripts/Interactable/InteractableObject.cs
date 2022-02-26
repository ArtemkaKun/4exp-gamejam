using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractableObject : MonoBehaviour
{
    [field: SerializeField]
    public UnityEvent OnInteract { get; private set; }

    public void PlayOpenAnimation(bool isPlaying)
    {
        Debug.Log(isPlaying ? "gramnko" : " nie");
    }
}
