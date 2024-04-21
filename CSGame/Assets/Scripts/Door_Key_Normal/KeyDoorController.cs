using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 

public class KeyDoorController : MonoBehaviour
{
    public bool isLocked = true; // Whether the door is currently locked
    public bool hasKey = false; // Whether the player has the key
    public float unlockDistance = 2f; // The distance within which the player must be to unlock the door
    public string sceneToLoad; // The name of the scene to load

    public Transform player; // Reference to the player's transform

    // Reference to the fade image
    public Image fadeImage;

    // Duration of the fade effect in seconds
    public float fadeDuration = 1f;

    void Start()
    {
        // Start the fade-out animation at the beginning of the game
        StartCoroutine(StartFadeOut());
    }
    void Update()
    {
       
        // Check for click event
        if (Input.GetMouseButtonDown(0)) // Left mouse button click
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform == this.transform && hasKey)
                {
                    StartCoroutine(FadeAndLoadScene());
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

    IEnumerator StartFadeOut()
    {
        // Fade out
        float fadeStartTime = Time.time;
        while (fadeImage.color.a > 0)
        {
            float t = (Time.time - fadeStartTime) / fadeDuration;
            fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, Mathf.Lerp(1, 0, t));
            yield return null;
        }
    }

    IEnumerator FadeAndLoadScene()
    {
        // Fade out
        float fadeStartTime = Time.time;
        while (fadeImage.color.a < 1)
        {
            float t = (Time.time - fadeStartTime) / fadeDuration;
            fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, Mathf.Lerp(0, 1, t));
            yield return null;
        }

        // Load the new scene
        SceneManager.LoadScene(sceneToLoad);

        // Fade in
        fadeStartTime = Time.time;
        while (fadeImage.color.a > 0)
        {
            float t = (Time.time - fadeStartTime) / fadeDuration;
            fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, Mathf.Lerp(1, 0, t));
            yield return null;
        }
    }
}