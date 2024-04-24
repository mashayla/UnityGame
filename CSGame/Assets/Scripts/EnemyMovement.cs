using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 3f; // Speed of the enemy
    private bool isImmovable = false; // Flag to check if the enemy is immovable

    void Update()
    {
        if (!isImmovable)
        {
            // Basic movement logic
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }

    // Coroutine to make the enemy immovable for a specified duration
    public IEnumerator MakeImmovable(float duration)
    {
        isImmovable = true;
        yield return new WaitForSeconds(duration);
        isImmovable = false;
    }
}