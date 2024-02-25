using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Animator animator;
    Rigidbody rb;
    public float moveSpeed = 5f; // Adjust this value to control the movement speed

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        bool isWalking = animator.GetBool("Walk");
        bool walkForward = Input.GetKey("w");
        bool isRunning = animator.GetBool("Run");
        bool runForward = Input.GetKey("r");
        bool isBackingUp = animator.GetBool("Back");
        bool backingUp = Input.GetKey("s");
        bool isJumping = animator.GetBool("Jump");
        bool jump = Input.GetKey(KeyCode.Space);
        bool isGoingLeft = animator.GetBool("Left");
        bool goLeft = Input.GetKey("a"); ;
        bool isGoingRight = animator.GetBool("Right");
        bool goRight = Input.GetKey("d"); ;


        //If player is not walking and pressing w:
        if (!isWalking && walkForward)
        {
            animator.SetBool("Walk", true);
        }
        //if player is walking and stops pressing w:
        if(isWalking && !walkForward)
        {
            animator.SetBool("Walk", false);
        }

        //If player is not running and pressing shift:
        if (!isRunning && runForward)
        {
            animator.SetBool("Run", true);
        }
        //if player is running and stops pressing shift:
        if (isRunning && !runForward)
        {
            animator.SetBool("Run", false);
        }

        //If player is not backing up and pressing s:
        if (!isBackingUp && backingUp)
        {
            animator.SetBool("Back", true);
        }
        //if player is backing up and stops pressing s:
        if (isBackingUp && !backingUp)
        {
            animator.SetBool("Back", false);
        }

        //If player is not jumping and pressing space bar:
        if (!isJumping && jump)
        {
            animator.SetBool("Jump", true);
        }
        //if player is jumping and stops pressing space bar:
        if (!jump)
        {
            animator.SetBool("Jump", false);
        }

        //If player is not going left and pressing a:
        if (!isGoingLeft && goLeft)
        {
            animator.SetBool("Left", true);
        }
        //if player is going left and stops pressing a:
        if (isGoingLeft && !goLeft)
        {
            animator.SetBool("Left", false);
        }

        //If player is not going right and pressing d:
        if (!isGoingRight && goRight)
        {
            animator.SetBool("Right", true);
        }
        //if player is going right and stops pressing d:
        if (isGoingRight && !goRight)
        {
            animator.SetBool("Right", false);
        }
    }
}
