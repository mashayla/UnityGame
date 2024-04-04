using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class KeyDoorController : MonoBehaviour
{
    public bool isLocked = true; // Whether the door is currently locked
    public bool hasKey = false; // Whether the player has the key
    public float unlockDistance = 2f; // The distance within which the player must be to unlock the door
    public string sceneToLoad; // The name of the scene to load

    public Transform player; // Reference to the player's transform

    // Removed the rotation-related variables since the door won't physically open

    void Update()
    {
        // Check if the player has the key and is within the unlock distance
        if (hasKey && Vector3.Distance(transform.position, player.position) <= unlockDistance)
        {
            // The door won't physically open, so no need to set a target angle
        }

        // Check for click event
        if (Input.GetMouseButtonDown(0)) // Left mouse button click
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform == this.transform && hasKey)
                {
                    LoadNewScene();
                }
            }
        }
    }

    // Method to set the hasKey variable directly
    public void SetHasKey(bool value)
    {
        hasKey = value;
        if (hasKey)
        {
            Debug.Log("Key picked up. Door can now be unlocked.");
        }
    }

    // Method to load a new scene
    void LoadNewScene()
    {
        if (!string.IsNullOrEmpty(sceneToLoad))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
        else
        {
            Debug.LogError("No scene specified to load.");
        }
    }
}