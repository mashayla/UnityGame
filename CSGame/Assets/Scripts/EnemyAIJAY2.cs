using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAIJAY2 : MonoBehaviour
{
    public float speed = 5f; // Speed of the enemy
    public float obstacleDistance = 10f; // Distance at which the enemy detects an obstacle

    private void Update()
    {
        // Raycast forward
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, obstacleDistance))
        {
            // If the raycast hits a wall
            if (hit.collider.CompareTag("Wall"))
            {
                // Rotate to a random direction
                transform.Rotate(0, Random.Range(0, 90), 0);
            }
        }

        // Move forward
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}