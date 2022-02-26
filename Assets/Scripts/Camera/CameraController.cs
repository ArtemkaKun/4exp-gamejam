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

    protected virtual void OnTriggerEnter(Collider collider)
    {
        if (IsObjectInteractable(collider.gameObject.layer) == true)
        {
            collider.GetComponent<InteractableObject>().OnPresence.Invoke();
        }
    }

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

					if (CurrentInteractableObject != null)
					{
						CurrentInteractableObject.OnInteract.Invoke();
					}
				}
            }
        }
    }

    private bool IsObjectInteractable(RaycastHit hit)
    {
        return hit.collider.transform.gameObject.layer == (int)Mathf.Log(InteractiveObjectsLayer.value, 2);
    }

    private bool IsObjectInteractable(int layer)
    {
        return layer == (int)Mathf.Log(InteractiveObjectsLayer.value, 2);
    }
}
