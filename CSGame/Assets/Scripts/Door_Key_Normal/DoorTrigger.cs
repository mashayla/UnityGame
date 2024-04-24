using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public DoorController doorController; // Reference to the DoorController script
    public Camera mainCamera; // Reference to the main camera

    void Update()
    {
        // Check if the left mouse button is clicked
        if (Input.GetMouseButtonDown(0))
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
                    doorController.ToggleDoor();
                }
            }
        }
    }
}