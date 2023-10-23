using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLerp : MonoBehaviour
{
    public GameObject cam;
    public PlayerCamera playerCamera;
    public PlayerMovement playerMovement;
    public ScreenInputDetect screenInputDetect;
    public GameObject cross;
    private Vector3 endPosition = new Vector3(-52f, -3f, -20.5f);
    private Vector3 originalPosition;
    private Quaternion originalRotation;
    private float desiredDuration = 0.5f;
    private bool isLerp = false;
    private bool isSit = false;

    private void Update() {
        if (!isSit && !isLerp && Input.GetKeyDown(KeyCode.E))
        {   
            // stop playing audio_walk after sitting
            if (audioPlayer.instance.audio_walk.isPlaying) {
                audioPlayer.instance.stop_audio_walk();
            }
            audioPlayer.instance.play_audio_sit();

            cross.SetActive(false);
            isLerp = true;
            originalPosition = transform.position;
            originalRotation = cam.transform.rotation;
            playerCamera.enabled = false;
            playerMovement.enabled = false;
            StartCoroutine(LerpCamera(transform.position, endPosition));
        }
        else if (isSit && !isLerp && Input.GetKey(KeyCode.E) && Input.GetKey(KeyCode.LeftShift))
        {
            cross.SetActive(true);
            isLerp = true;
            playerCamera.enabled = false;
            StartCoroutine(LerpCamera(transform.position, originalPosition));
        }
    }

    IEnumerator LerpCamera(Vector3 startPosition, Vector3 endPosition)
    {
        float elapsedTime = 0f;

        while (elapsedTime < desiredDuration)
        {
            float t = elapsedTime / desiredDuration;
            transform.position = Vector3.Lerp(startPosition, endPosition, t);
            
            if (isSit)
            {
                cam.transform.rotation = Quaternion.Lerp(transform.rotation, originalRotation, t);
            }
            else
            {
                cam.transform.rotation = Quaternion.Lerp(originalRotation, Quaternion.Euler(0f, -90f, 0f), t);
            }

            elapsedTime += Time.deltaTime;

            yield return null;
        }

        isSit = !isSit;
        screenInputDetect.enabled = isSit;
        isLerp = false;
        playerCamera.enabled = !isSit;
        playerMovement.enabled = !isSit;
        Cursor.visible = isSit;
        Cursor.lockState = isSit ? CursorLockMode.None : CursorLockMode.Locked;
        transform.position = endPosition;
    }
}
