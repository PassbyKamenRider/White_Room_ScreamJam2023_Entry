using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChairSit : MonoBehaviour
{
    public CameraLerp cameraLerp;
    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player")
        {
            cameraLerp.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.tag == "Player")
        {
            cameraLerp.enabled = false;
        }
    }
}
