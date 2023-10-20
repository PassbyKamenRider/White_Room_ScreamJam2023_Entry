using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScreenInputDetect : MonoBehaviour
{
    public LayerMask targetMasks = ~0;
    public float raycastDistance = 15f;
    public UnityEvent<Vector2> OnCursorInput = new UnityEvent<Vector2>();
    void Update()
    {
        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hitResult;

        if (Physics.Raycast(mouseRay, out hitResult, raycastDistance, targetMasks, QueryTriggerInteraction.Ignore))
        {
            if (hitResult.collider.gameObject != gameObject)
            {
                return;
            }

            OnCursorInput.Invoke(hitResult.textureCoord);
        }
    }
}