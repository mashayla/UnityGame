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

    public AIDestinationSetter enemyAIDestinationSetter; // Reference to the AIDestinationSetter component on the enemy
    public GameObject noPlayerSpot;

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
         //   enemyAIDestinationSetter.target.position = hardcodedDestination;
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
            // Set the enemy's destination to a random position
           
            // Temporarily hide the player model
            player.SetActive(false);
            enemyAIDestinationSetter.target = noPlayerSpot.transform;

        }
        else
        {
          //  enemyAIDestinationSetter.target = player.transform;

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
            enemyAIDestinationSetter.target = player.transform;
        }
    }

    void SetRandomDestination()
    {
        // Define the bounds of the area where the enemy can move (wheelchair)
        Vector3 location = new Vector3(6.105612f, 0.6259766f, -2.631168f);

        enemyAIDestinationSetter.target.position = location;
        Debug.Log("Setting enemy destination to: " + location);
    }
    void ResetDestinationToPlayer()
    {
        // Set the enemy's destination back to the player
        enemyAIDestinationSetter.target = player.transform;
    }
}

