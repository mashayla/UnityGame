using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeySpawner : MonoBehaviour
{
    public GameObject rusty_key; // Reference to the key GameObject

    // Hardcoded predefined positions
    private Vector3[] predefinedPositions = new Vector3[]
    {
        new Vector3(0.12f, 3.54f, 9.24f),
        new Vector3(-14.12f, 3.65f, 11.49f),
        new Vector3(-14.65f, 4.34f, 9.21f),
        new Vector3(12.49f, 3.43f, 3.72f),
        new Vector3(14.08f, 4.12f, 6.13f),
        new Vector3(9.66f, 3.38f, -0.42f),
        new Vector3(8.74f, 4.71f, -10.62f),
        new Vector3(1.68f, 3.99f, -10.9f),
        new Vector3(-5.94f, 4.56f, -14.94f),
        new Vector3(10f, 3f, 7f),
    };

    void Start()
    {
        // Ensure the key GameObject is assigned in the inspector
        if (rusty_key == null)
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
