using UnityEngine.AI;


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PatrolBehavior : StateMachineBehaviour
{
    float timer;


    //creating a list to add a reference to the waypoints
    List<Transform> wayPoints = new List<Transform>();


    // adding a  reference to the navmesh agent
   NavMeshAgent agent;

    //Transform player;


    //
    //float ChaseRange = 15;


    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = 0;


        //access the object by using the tag
        Transform way_points_objects = GameObject.FindGameObjectWithTag("WayPoints").transform;


        //looping through all the children and assign them to the list created
        foreach (Transform t in way_points_objects)
           wayPoints.Add(t);


        // access the navMesh
        agent = animator.GetComponent<NavMeshAgent>();

        //
        agent.SetDestination(wayPoints[Random.Range(0, wayPoints.Count)].position);
        //agent.SetDestination(wayPoints[0].position);


        //find the player object
        //player = GameObject.FindGameObjectWithTag("Player").transform;
    }


    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {


        if (agent.remainingDistance <= agent.stoppingDistance)
            agent.SetDestination(wayPoints[Random.Range(0, wayPoints.Count)].position);
        timer += Time.deltaTime;
        if (timer > 15)
        {
            //switch to the patrol state
            animator.SetBool("isPatrolling", false);
        }


        //calculate the distance
        //float distance = Vector3.Distance(animator.transform.position, player.position);


        //checks if the distance 
       // if (distance < ChaseRange)
            //chase the player
         //   animator.SetBool("isChasing", true);
    }


    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(agent.transform.position);
    }


    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}


    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}