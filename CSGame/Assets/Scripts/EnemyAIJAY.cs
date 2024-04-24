using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAIJAY : MonoBehaviour
{
    public float lookRadius = 10f;  // Detection range for player
    public float attackRadius = 5f; // Attack range
    public float radiusIncreaseInterval = 30f; // Interval to increase the lookRadius
    public float radiusIncreaseAmount = 1f; // Amount to increase the lookRadius

    public Transform[] patrolPoints; // Array of patrol points
    private int currentPatrolIndex = 0; // Current patrol point index

    public float waitTime = 3f; // Time to wait at each patrol point
    private bool isWaiting = false; // Flag to check if the enemy is waiting

    Transform target;  // Reference to the player
    NavMeshAgent agent; // Reference to the NavMeshAgent

    void Start()
    {
        target = PlayerController.instance.playerCamera.transform;
        agent = GetComponent<NavMeshAgent>();

        // Start the IncreaseLookRadius coroutine
        StartCoroutine(IncreaseLookRadius());
    }

    void Update()
{
    // Distance to the target
    float distance = Vector3.Distance(target.position, transform.position);

    // If inside the lookRadius
    if (distance <= lookRadius)
    {
        // Move towards the target
        agent.SetDestination(target.position);

        // If within attacking distance
        if (distance <= attackRadius)
        {
            // Attack the target
            // Add your attack logic here
        }
    }
    else
    {
        // Check if the agent has reached its destination
        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance && !isWaiting)
        {
            // Start the WaitAndGo coroutine
            StartCoroutine(WaitAndGo());
        }
    }
}
    // Coroutine to increase the lookRadius
    IEnumerator IncreaseLookRadius()
    {
        while (true)
        {
            yield return new WaitForSeconds(radiusIncreaseInterval);
            lookRadius += radiusIncreaseAmount;
        }
    }

    // Coroutine to wait for a specified duration and then go to the next patrol point
    IEnumerator WaitAndGo()
    {
        isWaiting = true;
        yield return new WaitForSeconds(waitTime);
        currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;
        agent.SetDestination(patrolPoints[currentPatrolIndex].position);
        isWaiting = false;
    }
}
