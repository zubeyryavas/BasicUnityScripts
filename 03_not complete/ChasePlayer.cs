using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasePlayer : StateMachineBehaviour
{
    public float speed = 2;
    private Transform player;
    private Rigidbody2D rb;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {


        if (Vector2.Distance(rb.position, player.position) < 6)
        {

            animator.SetBool("Chase", true);

            if (Vector2.Distance(rb.position, player.position) < 1)
            {
                animator.SetTrigger("Attack");
            }
        }
        else
            animator.SetBool("Chase", false);

    }
}

    
