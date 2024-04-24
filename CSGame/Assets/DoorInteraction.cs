
using UnityEngine;
using Pathfinding; // Include the pathfinding namespace

public class DoorInteraction : MonoBehaviour {
    public float openAngle = 90f; // The angle at which the door is fully open
    public float closeSpeed = 2f; // Speed at which the door closes
    public float openSpeed = 2f; // Speed at which the door opens
    public bool isOpen = false; // Whether the door is currently open

    private float targetAngle;
    private float currentAngle;
    private Vector3 initialRotation;
    private Collider doorCollider; // The door's collider

    void Start() {
        // Store the initial rotation of the door
        initialRotation = transform.eulerAngles;
        // Set the target angle to the initial rotation
        targetAngle = initialRotation.y;
        // Set the current angle to the initial rotation
        currentAngle = initialRotation.y;
        // Get the door's collider
        doorCollider = GetComponent<Collider>();
    }

    void Update() {
        // If the door is supposed to be open
        if (isOpen) {
            // Calculate the target angle
            targetAngle = initialRotation.y + openAngle;
        } else {
            // Calculate the target angle
            targetAngle = initialRotation.y;
        }

        // Smoothly rotate the door towards the target angle
        currentAngle = Mathf.LerpAngle(currentAngle, targetAngle, Time.deltaTime * (isOpen ? openSpeed : closeSpeed));
        // Apply the rotation
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, currentAngle, transform.eulerAngles.z);
    }

    // Call this method to toggle the door's open state
    public void ToggleDoor() {
        isOpen = !isOpen;

        // Update door's walkability
        doorCollider.enabled = !isOpen; // Disable the collider if the door is open

        // Update the graph with the door's new walkability status
        UpdateGraph();
    }

    // Updates the navigation graph to make the door walkable or unwalkable
    private void UpdateGraph() {
        /// Create a new GraphUpdateObject with the door's bounds
        Bounds bounds = doorCollider.bounds;
        GraphUpdateObject guo = new GraphUpdateObject(bounds);
        
        // Change walkability and apply the update to the graph
        guo.modifyWalkability = true;
        guo.setWalkability = isOpen; // The nodes covered by the collider should be walkable when the door is open
        AstarPath.active.UpdateGraphs(guo);
    }
}
