using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [field: SerializeField]
    private Camera Camera { get; set; }
    [field: SerializeField]
    private float Distance { get; set; } = 5.0f;
    [field: SerializeField]
    private LayerMask InteractiveObjectsLayer { get; set; }

    private RaycastHit CachedHit;
    private InteractableObject CurrentInteractableObject;

    protected virtual void Update()
    {
        GetInteractiveObject();
    }

    private void GetInteractiveObject()
    {
        Vector3 origin = Camera.main.transform.position;
        Vector3 direction = Camera.main.transform.forward;

        if (Physics.Raycast(origin, direction, out CachedHit, Distance))
        {
            if (IsObjectInteractable(CachedHit) == true)
            {
                if (Input.GetKeyDown(KeyCode.Mouse0) == true)
                {
                    CurrentInteractableObject = CachedHit.transform.GetComponent<InteractableObject>();

                    CurrentInteractableObject.OnInteract.Invoke();
                }
            }
        }
    }

    private bool IsObjectInteractable(RaycastHit hit)
    {
        return hit.transform.gameObject.layer == (int)Mathf.Log(InteractiveObjectsLayer.value, 2);
    }
}
