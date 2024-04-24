using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyRandomizer : MonoBehaviour
{
    public GameObject rusty_key; // Reference to the key GameObject

    // Hardcoded predefined positions
    private Vector3[] predefinedPositions = new Vector3[]
    {
        new Vector3(0.12, 3.54, 9.24),
        new Vector3(-14.12, 3.65, 11.49),
        new Vector3(-14.65, 4.34, 9.21),
        new Vector3(12.49, 3.43, 3.72),
        new Vector3(14.08, 4.12, 6.13),
        new Vector3(9.66, 3.38, -0.42),
        new Vector3(8.74, 4.71, -10.62),
        new Vector3(1.68, 3.99, -10.9),
        new Vector3(-5.94, 4.56, -14.94),
        new Vector3(10, 3, 7)
    };

    void Start()
    {
        // Ensure the key GameObject is assigned in the inspector
        if (key == null)
        {
            Debug.LogError("Key GameObject not assigned.");
            return;
        }

        // Randomly select a position from the predefined positions
        int randomIndex = Random.Range(0, predefinedPositions.Length);
        Vector3 randomPosition = predefinedPositions[randomIndex];

        // Set the key's position to the randomly selected position
        key.transform.position = randomPosition;
    }
}