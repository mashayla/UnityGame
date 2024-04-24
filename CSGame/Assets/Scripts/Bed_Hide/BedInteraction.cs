using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedInteraction : MonoBehaviour
{
    public GameObject player; // Assign your player model here
    public Camera mainCamera; // Assign your main camera here
    public GameObject cameraPositionObject; // Assign the empty GameObject under the bed here
    public GameObject playerCapsulePos;
    public CharacterController setupController;

    public Seeker enemySeeker; // Reference to the Seeker component on the player


    private bool isUnderBed = false;
    private Vector3 originalPlayerPosition;
    private Vector3 originalCameraPosition;
    private Quaternion originalControllerRotation;
    private Vector3 originalControllerPosition;
    private Vector3 originalPlayerCapsulePosition;

    void Update()
    {
       
        if (Input.GetMouseButtonDown(0)) // Left mouse button click
        {
            RaycastHit hit;
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform == this.transform) // If the bed is clicked
                {
                    ToggleUnderBed();
                }
            }
        }
    }

    void ToggleUnderBed()
    {
        isUnderBed = !isUnderBed;

        if (isUnderBed)
        {
            

            // Store the original Character Controller orientation
            originalControllerRotation = setupController.transform.rotation;
            originalControllerPosition = setupController.transform.position;

            setupController.enabled = false;
    
            // Store the original player and camera positions and rotations
            originalPlayerPosition = player.transform.position;
            originalCameraPosition = mainCamera.transform.position;
            originalPlayerCapsulePosition = playerCapsulePos.transform.position;
            
            // Move player to the camera position object
            player.transform.position = cameraPositionObject.transform.position;
            playerCapsulePos.transform.position = cameraPositionObject.transform.position;
            mainCamera.transform.position = cameraPositionObject.transform.position;

            // Temporarily hide the player model
            player.SetActive(false);
            // Disable the Seeker to stop pathfinding
            enemySeeker.enabled = false;
        }
        else
        {

            // Restore the Character Controller's orientation
            setupController.transform.rotation = originalControllerRotation;
            setupController.transform.position = originalControllerPosition;

            setupController.enabled = true;
            // Restore player and camera positions and rotations
            player.transform.position = originalPlayerPosition;
            mainCamera.transform.position = originalCameraPosition;
            playerCapsulePos.transform.position = originalPlayerCapsulePosition;

            // Ensure the Character Controller is aligned with the player model
            setupController.transform.position = player.transform.position;

            // Make the player model visible again
            player.SetActive(true);
            // Re-enable the enemy's Seeker component
            enemySeeker.enabled = true;
        }
    }
}

