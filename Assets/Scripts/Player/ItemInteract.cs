using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInteract : MonoBehaviour
{
    public Camera playerCamera;
    public LayerMask pickupMask;
    public LayerMask edibleMask;
    public Transform pickupPoint;
    public Transform playerCameraTransform;
    public GameObject plateDropPlace;
    public BoxCollider chairCollider;
    private float rotationSpeed = 10.0f;
    private float interactRange = 5.0f;
    private Rigidbody currentPickup;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Ray cameraRay = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
            if (Physics.Raycast(cameraRay, out RaycastHit hitinfo, interactRange, pickupMask))
            {
                currentPickup = hitinfo.rigidbody;
                chairCollider.enabled = false;
                if (hitinfo.transform.name == "plate")
                {
                    plateDropPlace.SetActive(true);
                }
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray cameraRay = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
            if (Physics.Raycast(cameraRay, out RaycastHit hitinfo, interactRange, edibleMask))
            {
                Destroy(hitinfo.collider.gameObject);
            }
        }
    }

    private void FixedUpdate() {
        if (currentPickup)
        {
            Vector3 directionToTarget = pickupPoint.position - currentPickup.position;
            float distanceToTarget = directionToTarget.magnitude;
            currentPickup.velocity = directionToTarget * 12f * distanceToTarget;
            currentPickup.transform.rotation = Quaternion.Lerp(currentPickup.transform.rotation,
                                                            Quaternion.Euler(0f, 180f + playerCameraTransform.rotation.eulerAngles.y, 0f),
                                                            rotationSpeed * Time.deltaTime);
        }
    }

    public void DropItem(Vector3 position, Vector3 rotation, bool canBeRetrieved)
    {
        if (currentPickup)
        {
            currentPickup.velocity = Vector3.zero;
            currentPickup.position = position;
            currentPickup.rotation = Quaternion.Euler(rotation);

            if (!canBeRetrieved)
                currentPickup.transform.gameObject.layer = LayerMask.NameToLayer("Default");

            foreach (Transform child in currentPickup.transform)
            {
                if (child.tag == "ToEat")
                {
                    child.gameObject.layer = LayerMask.NameToLayer("Edible");
                }
            }

            chairCollider.enabled = true;
            currentPickup = null;
        }
    }
}
