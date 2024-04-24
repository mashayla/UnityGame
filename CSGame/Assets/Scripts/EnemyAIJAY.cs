using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAIJAY : MonoBehaviour
{
    public float lookRadius = 10f;  // Detection range for player
    public float attackRadius = 5f; // Attack range

    Transform target;  // Reference to the player
    UnityEngine.AI.NavMeshAgent agent; // Reference to the NavMeshAgent

    void Start()
    {
        target = PlayerController.instance.playerCamera.transform;
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    void Update()
    {
        // Distance to the player
        float distance = Vector3.Distance(target.position, transform.position);

        // If inside the lookRadius
        if (distance <= lookRadius)
        {
            // Move towards the player
            agent.SetDestination(target.position);

            // If within attacking distance
            if (distance <= attackRadius)
            {
                // Attack the player
                // Add your attack code here
                Debug.Log("Attack the player");
            }
        }
        else
        {
            // Move around randomly
            Vector3 randomDirection = Random.insideUnitSphere * lookRadius;
            randomDirection += transform.position;
            UnityEngine.AI.NavMeshHit hit;
            UnityEngine.AI.NavMesh.SamplePosition(randomDirection, out hit, lookRadius, 1);
            agent.SetDestination(hit.position);
        }
    }

    // Show the lookRadius in editor
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }
}