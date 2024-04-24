using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyPickup : MonoBehaviour
{
    public KeyDoorController keyDoorController; // Reference to the KeyDoorController script
    public float pickupDistance = 2f; // The distance within which the player must be to pick up the key
    public Transform player; // Reference to the player's transform

    // Add a reference to the Text component for the message
    public Text pickupText;
    public float fadeDuration = 1f; // Duration of the fade effect

    private bool hasPickedUpKey = false; // Flag to track if the key has been picked up

    void Update()
    {
        // Check if the player is within the pickup distance and clicks the mouse
        if (Vector3.Distance(transform.position, player.position) <= pickupDistance && Input.GetMouseButtonDown(0))
        {
            // Check if the key has already been picked up
            if (!hasPickedUpKey)
            {
                // Call the SetHasKey method on the KeyDoorController to set hasKey to true
                keyDoorController.SetHasKey(true);

            
                // Display the pickup message
                StartCoroutine(FadeText());
                // Set the flag to true to indicate the key has been picked up
                hasPickedUpKey = true;
              
            }
        }
    }

    IEnumerator FadeText()
    {
        // Fade in
        float fadeStartTime = Time.time;
        while (pickupText.color.a < 1)
        {
            float t = (Time.time - fadeStartTime) / fadeDuration;
            pickupText.color = new Color(pickupText.color.r, pickupText.color.g, pickupText.color.b, Mathf.Lerp(0, 1, t));
            yield return null;
        }

        // Wait for 3 seconds
        //yield return new WaitForSeconds(3f);
        Destroy(gameObject);
        // Fade out
      //  fadeStartTime = Time.time;
      //  while (pickupText.color.a > 0)
     //   {
     //       float t = (Time.time - fadeStartTime) / fadeDuration;
     //       pickupText.color = new Color(pickupText.color.r, pickupText.color.g, pickupText.color.b, Mathf.Lerp(1, 0, t));
     //       yield return null;
    //    }
     
    }
}