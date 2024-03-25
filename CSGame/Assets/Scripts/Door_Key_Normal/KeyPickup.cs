using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    public KeyDoorController keyDoorController; // Reference to the KeyDoorController script
    public float pickupDistance = 2f; // The distance within which the player must be to pick up the key
    public Transform player; // Reference to the player's transform

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
    }
}
