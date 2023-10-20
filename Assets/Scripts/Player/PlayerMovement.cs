using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;

    public Transform orientation;

    private float horizontalInput;
    private float verticalInput;

    private Vector3 moveDirection;

    private Rigidbody rb;

    private void Start() {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void Update() {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        //handle audio_walk
        if ((horizontalInput != 0 || verticalInput != 0) && !audioPlayer.instance.audio_walk.isPlaying)
        {
            audioPlayer.instance.play_audio_walk();
        } else if (horizontalInput == 0 && verticalInput == 0 && audioPlayer.instance.audio_walk.isPlaying)
        {
            audioPlayer.instance.stop_audio_walk();
        }

        Vector3 groundSpeed = new Vector3(rb.velocity.x, 0, rb.velocity.z);
        if (groundSpeed.magnitude > moveSpeed)
        {
            Vector3 newSpeed = groundSpeed.normalized * moveSpeed;
            rb.velocity = new Vector3(newSpeed.x, rb.velocity.y, newSpeed.z);
        }
    }

    private void FixedUpdate() {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
    }
}
