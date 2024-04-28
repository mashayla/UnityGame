using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAIJAY : MonoBehaviour
{
    public float lookRadius = 10f; // Detection range for player
    public float attackRadius = 5f; // Attack range
    public float radiusIncreaseInterval = 30f; // Interval to increase the lookRadius
    public float radiusIncreaseAmount = 1f; // Amount to increase the lookRadius
    public float obstacleDistance = 10f; // Distance at which the enemy detects an obstacle
    public float damagePercentage = 0.3f; // Damage percentage

    public Transform[] patrolPoints; // Array of patrol points
    private int currentPatrolIndex = 0; // Current patrol point index

    public float waitTime = 3f; // Time to wait at each patrol point
    private bool isWaiting = false; // Flag to check if the enemy is waiting

    Transform target; // Reference to the player
    NavMeshAgent agent; // Reference to the NavMeshAgent
    PlayerController playerController; // Reference to the PlayerController script

    void Start()
    {
        target = PlayerController.instance.transform;
        agent = GetComponent<NavMeshAgent>();
        playerController = PlayerController.instance; // Assuming PlayerController is a singleton

        // Start the IncreaseLookRadius coroutine
        StartCoroutine(IncreaseLookRadius());
    }

    void Update()
{
    // Check if the player is within the lookRadius
    if (Vector3.Distance(transform.position, target.position) <= lookRadius)
    {
        // Player detected, follow the player
        agent.SetDestination(target.position);

        // Attack mechanism
        if (Vector3.Distance(transform.position, target.position) <= attackRadius)
        {
            // Player is within attack range, attack
            AttackPlayer();
        }
    }
    else
    {
        // Player not detected, patrol
        if (!isWaiting && !agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            // If at the current patrol point, wait and then move to the next one
            StartCoroutine(WaitAndGo());
        }
    }

    // Wall detection and avoidance
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
}

    void AttackPlayer()
    {
        // Assuming the PlayerController has a method to reduce health by a percentage
        playerController.ReduceHPByPercentage(damagePercentage);
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