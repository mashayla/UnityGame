using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScalpelPickup : MonoBehaviour
{
    public float pickupDistance = 2f; // The distance within which the player must be to pick up the scalpel
    public Transform player; // Reference to the player's transform
    public PlayerController playerController; // Reference to the PlayerController script
    public Transform scalpelHolder; // Reference to the empty GameObject where the scalpel will be placed
 
    // Add a reference to the Text component
    public Text pickupText;
    public float fadeDuration = 1f; // Duration of the fade effect
    private bool hasPickedUpScalpel = false; // Flag to track if the scalpel has been picked up
    void Update()
    {
        // Check if the player is within the pickup distance and clicks the mouse
        if (Vector3.Distance(transform.position, player.position) <= pickupDistance && Input.GetMouseButtonDown(0))
        {
            // Check if the scalpel has already been picked up
            if (!hasPickedUpScalpel)
            {
                //set its parent to the scalpelHolder
                transform.SetParent(scalpelHolder);

                // reset the local position and rotation of the scalpel to match the scalpelHolder
                transform.localPosition = Vector3.zero;
                transform.localRotation = Quaternion.identity;
                hasPickedUpScalpel = true;
                // Start the fade-in and fade-out coroutine
                StartCoroutine(FadeText());
              
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
            yield return new WaitForSeconds(3f);

            // Fade out
            fadeStartTime = Time.time;
            while (pickupText.color.a > 0)
            {
                float t = (Time.time - fadeStartTime) / fadeDuration;
                pickupText.color = new Color(pickupText.color.r, pickupText.color.g, pickupText.color.b, Mathf.Lerp(1, 0, t));
                yield return null;
            }
            //reset to false for next scalpel?
       // hasPickedUpScalpel = false;
        }
    }
