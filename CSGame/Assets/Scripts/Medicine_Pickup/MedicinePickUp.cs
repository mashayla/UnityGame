using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; // Required for handling click events

public class MedicineBottlePickup : MonoBehaviour
{
    public float pickupDistance = 2f; // The distance within which the player must be to pick up the medicine bottle
    public Transform player; // Reference to the player's transform
    public PlayerController playerController; // Reference to the PlayerController script


    void Update()
    {
        // Check if the player is within the pickup distance and clicks the mouse
        if (Vector3.Distance(transform.position, player.position) <= pickupDistance && Input.GetMouseButtonDown(0))
        {
            // Call the IncreaseHP method on the PlayerHealth script to increase HP
            playerController.IncreaseHP(10); // Assuming you want to increase HP by 10

            // Optionally, destroy the medicine bottle object or deactivate it
            Destroy(gameObject);
        }
    }
}