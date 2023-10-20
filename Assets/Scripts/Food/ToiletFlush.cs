using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToiletFlush : MonoBehaviour
{
    private bool isTriggered;

    private void Update() {
        if (isTriggered && Input.GetKeyDown(KeyCode.E))
        {
            // toilet flush
            Debug.Log("Flush toilet");
            audioPlayer.instance.play_audio_flush();
        }
    }

    private void OnTriggerEnter(Collider other) {
        isTriggered = true;
    }

    private void OnTriggerExit(Collider other) {
        isTriggered = false;
    }
}
