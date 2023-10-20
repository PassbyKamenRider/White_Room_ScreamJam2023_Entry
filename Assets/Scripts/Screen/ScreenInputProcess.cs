using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ScreenInputProcess : MonoBehaviour
{
    public RectTransform canvasTransform;
    private GraphicRaycaster raycaster;

    private void Start() {
        raycaster = GetComponent<GraphicRaycaster>();
    }

    public void OnCursorInput(Vector2 normalizedPos)
    {
        Vector3 mousePosition = new Vector3(canvasTransform.sizeDelta.x * normalizedPos.x,
                                            canvasTransform.sizeDelta.y * normalizedPos.y,
                                            0f);

        PointerEventData mouseEvent = new PointerEventData(EventSystem.current);
        mouseEvent.position = mousePosition;

        List<RaycastResult> results = new List<RaycastResult>();
        raycaster.Raycast(mouseEvent, results);

        bool sendMouseDown = Input.GetMouseButtonDown(0);
        bool sendMouseUp = Input.GetMouseButtonUp(0);

        foreach (RaycastResult result in results)
        {
            if (sendMouseDown)
            {
                ExecuteEvents.Execute(result.gameObject, new PointerEventData(EventSystem.current), ExecuteEvents.pointerDownHandler);
            }
            if (sendMouseUp)
            {
                ExecuteEvents.Execute(result.gameObject, new PointerEventData(EventSystem.current), ExecuteEvents.pointerUpHandler);
            }
        }

        // play mouse-click sound

        if (Input.GetMouseButtonDown(0))
        {
            audioPlayer.instance.play_audio_mouse();
        }
    }
}
