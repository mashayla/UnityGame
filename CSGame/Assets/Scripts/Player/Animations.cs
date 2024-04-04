using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour
{
    public Animator animator;
  //  private bool isJumping = false;


    void Update()
    {
        animator.SetFloat("Vertical", Input.GetAxis("Vertical"));
        animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
        //Jump
        bool isJumping = animator.GetBool("Jump");
        bool jump = Input.GetKey(KeyCode.Space);

        //Stab
        bool isStabbing = animator.GetBool("Stab");
        bool stab = Input.GetKey("e");


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

        //If player is not stabbing and pressing e:
        if (!isStabbing && stab)
        {
            animator.SetBool("Stab", true);
        }
        //if player is stabbing and pressing e:
        if (!stab)
        {
            animator.SetBool("Stab", false);
        }


    }
}