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
    // Check if the agent has reached its destination
    if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
    {
        // If at the current patrol point, move to the next one
        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;
            agent.SetDestination(patrolPoints[currentPatrolIndex].position);
        }
    }
    else
    {
        // If not at the current patrol point, continue moving towards it
        agent.SetDestination(patrolPoints[currentPatrolIndex].position);
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
