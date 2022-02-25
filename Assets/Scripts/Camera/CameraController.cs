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

    protected virtual void Update()
    {
        GetInteractiveObject();
    }

    private void GetInteractiveObject()
    {
        RaycastHit hit;
        Vector3 origin = Camera.main.transform.position;
        Vector3 direction = Camera.main.transform.forward;

        if (Physics.Raycast(origin, direction, out hit, Distance))
        {
            if (hit.transform.gameObject.layer == (int)Mathf.Log(InteractiveObjectsLayer.value, 2)) ;
            {
                Debug.Log("to ten objekt");
            }
        }
    }
}
