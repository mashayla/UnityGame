using UnityEngine;
using Pathfinding; // Include the Pathfinding namespace if you're using methods from the A* Project

public class EnemyDoorInteraction : MonoBehaviour
{
    public Transform doorTransform; // The door's transform
    public float interactionDistance = 1.5f; // Distance within which the door should be interacted with
    public GraphUpdateScene graphUpdateScene; // Reference to the GraphUpdateScene component on the door
    public float doorOpenDistance = 1f; // Distance within which the door should open

    private bool doorIsOpen = false; // Tracks if the door is already opened

    private void Update()
    {
        // Check the distance between the enemy and the door
        if (Vector3.Distance(transform.position, doorTransform.position) <= interactionDistance)
        {
            InteractWithDoor();
        }
    }

    private void InteractWithDoor()
    {
        // If we are close enough and the door is not already open
        if (!doorIsOpen && Vector3.Distance(transform.position, doorTransform.position) <= doorOpenDistance)
        {
            OpenDoor();
        }
    }

    private void OpenDoor()
    {
        // Perform the door opening logic, e.g., play an animation
        // Ensure you have an Animator component attached to the door with a parameter named "Open"
       // if (doorTransform.TryGetComponent<Animator>(out var doorAnimator))
       // {
         //   doorAnimator.SetTrigger("isOpen");
      //  }

        // Disable the collider so the enemy can pass through
        if (doorTransform.TryGetComponent<Collider>(out var doorCollider))
        {
            doorCollider.isTrigger = true;
       }

        // Update the pathfinding graph if the door state affects walkability
        if (graphUpdateScene != null)
        {
            // Assume the GraphUpdateScene has a public method 'UpdateGraph' that you've created
            // which triggers a graph update, this is pseudo-code and needs to be implemented
            graphUpdateScene.Apply(); // You need to implement this according to your pathfinding setup
        }

        doorIsOpen = true;
    }
}
