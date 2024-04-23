using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PickUpText : MonoBehaviour
{
    public Text popUpText;
    public float fadeDuration = 1f; // Duration of the fade effect

    public void ShowMessage(string message)
    {
        StartCoroutine(FadeInText(message));
    }

    IEnumerator FadeInText(string message)
    {
        // Fade in
        float fadeStartTime = Time.time;
        while (popUpText.color.a < 1)
        {
            float t = (Time.time - fadeStartTime) / fadeDuration;
            popUpText.color = new Color(popUpText.color.r, popUpText.color.g, popUpText.color.b, Mathf.Lerp(0, 1, t));
            yield return null;
        }

        // Display the message
        popUpText.text = message;
        popUpText.gameObject.SetActive(true);

        // Fade out after 3 seconds
        yield return new WaitForSeconds(3f);
        StartCoroutine(FadeOutText());
    }

    IEnumerator FadeOutText()
    {
        // Fade out
        float fadeStartTime = Time.time;
        while (popUpText.color.a > 0)
        {
            float t = (Time.time - fadeStartTime) / fadeDuration;
            popUpText.color = new Color(popUpText.color.r, popUpText.color.g, popUpText.color.b, Mathf.Lerp(1, 0, t));
            yield return null;
        }

        // Hide the text
        popUpText.gameObject.SetActive(false);
    }
}
