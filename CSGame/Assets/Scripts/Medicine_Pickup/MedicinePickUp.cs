using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MedicineBottlePickup : MonoBehaviour
{
    public float pickupDistance = 2f; // The distance within which the player must be to pick up the medicine bottle
    public Transform player; // Reference to the player's transform
    public PlayerController playerController; // Reference to the PlayerController script

    // Add a reference to the Text component
    public Text pickupText;
    public float fadeDuration = 1f; // Duration of the fade effect
    private bool hasPickedUpMedicine = false; // Flag to track if the pills have been picked up

    void Update()
    {
        // Check if the player is within the pickup distance and clicks the mouse
        if (Vector3.Distance(transform.position, player.position) <= pickupDistance && Input.GetMouseButtonDown(0))
        {
            if (!hasPickedUpMedicine)
            {
                // Call the IncreaseHP method on the PlayerHealth script to increase HP
                playerController.IncreaseHP(10);
               
                hasPickedUpMedicine = true;
                StartCoroutine(FadeText());
                Destroy(gameObject);
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
        yield return new WaitForSeconds(5f);

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
       Debug.Log("FadeText coroutine completed");
    }
}