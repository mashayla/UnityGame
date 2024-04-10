using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScalpelPickup : MonoBehaviour
{
    public float pickupDistance = 2f; // The distance within which the player must be to pick up the scalpel
    public Transform player; // Reference to the player's transform
    public PlayerController playerController; // Reference to the PlayerController script
    public Transform scalpelHolder; // Reference to the empty GameObject where the scalpel will be placed

    void Update()
    {
        // Check if the player is within the pickup distance and clicks the mouse
        if (Vector3.Distance(transform.position, player.position) <= pickupDistance && Input.GetMouseButtonDown(0))
        {
            //set its parent to the scalpelHolder
            transform.SetParent(scalpelHolder);

            // Optionally, reset the local position and rotation of the scalpel to match the scalpelHolder
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;

            // Optionally, deactivate the scalpel object to prevent it from being picked up again
           // gameObject.SetActive(false);
        }
    }
}
