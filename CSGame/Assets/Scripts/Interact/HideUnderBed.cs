using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideUnderBed : MonoBehaviour
{
    public float interactionDistance = 2f; // Maximum distance for interaction
    public LayerMask interactionLayer; // Layer mask to filter which objects can be interacted with

    void Update()
    {
        // Check if the player clicks
        if (Input.GetMouseButtonDown(0))
        {
            // Perform raycast from the mouse position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Check if the ray intersects with an object on the interaction layer
            if (Physics.Raycast(ray, out hit, interactionDistance, interactionLayer))
            {
                // Check if the hit object is the bed
                if (hit.collider.gameObject == gameObject)
                {
                    // Perform interaction with the bed
                    InteractWithBed();
                }
            }
        }
    }

    void InteractWithBed()
    {
        // Perform actions when the player interacts with the bed
        Debug.Log("Player interacted with the bed!");
    }
}
