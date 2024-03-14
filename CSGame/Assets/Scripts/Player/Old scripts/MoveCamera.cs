using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Transform playerTransform; // Reference to the player's transform

    void Update()
    {
        // Check if playerTransform is assigned
        if (playerTransform != null)
        {
            // Set the position of the camera to the position of the player
            transform.position = playerTransform.position;
        }
        else
        {
            // If playerTransform is not assigned, log a warning
            Debug.LogWarning("Player Transform not assigned to MoveCamera script!");
        }
    }
}
