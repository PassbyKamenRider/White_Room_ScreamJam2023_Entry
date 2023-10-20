using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropPlate : MonoBehaviour
{
    private bool isTriggered;
    public ItemInteract foodPickup;
    public Vector3 targetPosition;
    public Vector3 targetRotation;
    public bool canBeRetrieved;

    private void Update() {
        if (isTriggered && Input.GetKeyDown(KeyCode.F))
        {
            foodPickup.DropItem(targetPosition, targetRotation, canBeRetrieved);
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player")
        {
            isTriggered = true;
        }
    }
    
    private void OnTriggerExit(Collider other) {
        if (other.tag == "Player")
        {
            isTriggered = false;
        }
    }
}
