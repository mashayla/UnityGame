using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    public KeyDoorController keyDoorController; // Reference to the KeyDoorController script
    public float pickupDistance = 2f; // The distance within which the player must be to pick up the key
    public Transform player; // Reference to the player's transform
    public Camera mainCamera; // Reference to the main camera

    void Update()
    {
        // Check if the player is within the pickup distance and clicks the mouse
        if (Vector3.Distance(transform.position, player.position) <= pickupDistance && Input.GetMouseButtonDown(0))
        {
            // Call the SetHasKey method on the KeyDoorController to set hasKey to true
            keyDoorController.SetHasKey(true);
            // Optionally, destroy the key object or deactivate it
            Destroy(gameObject);
        }

        // Check if the player has the key and the left mouse button is clicked
        if (keyDoorController.hasKey && Input.GetMouseButtonDown(0))
        {
            // Create a ray from the camera to the mouse position
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Check if the ray hits the door
            if (Physics.Raycast(ray, out hit))
            {
                // Check if the hit object is the door
                if (hit.collider.gameObject == this.gameObject)
                {
                    // Toggle the door
                    keyDoorController.ToggleDoor();
                }
            }
        }
    }
}