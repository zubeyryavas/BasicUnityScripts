using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {


    public int speed;
    public int jumpForce;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private bool isGrounded;

    private Animator animator;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
        sr = GetComponent<SpriteRenderer>();
        isGrounded = true;

        animator = GetComponent<Animator>();

    }

    void Update() {
        Move();
        Jump();
    }

    void Move() {
        float xDisplacement = Input.GetAxis("Horizontal");
        if (xDisplacement > 0) {
            sr.flipX = false;
        } else if (xDisplacement < 0) {
            sr.flipX = true;
        }

        rb.velocity = new Vector2(xDisplacement * speed, rb.velocity.y);

        //rb.velocity = new Vector2((moveDirection) * speed, rb.velocity.y);
        animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
    }

    void Jump() {
        if (Input.GetButtonDown("Jump") && isGrounded) {
            isGrounded = false;
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);

            animator.SetBool("Jump", true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Ground")) {
            animator.SetBool("Jump", false);
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Ground")) {
            animator.SetBool("Jump", true);
            isGrounded = false;
        }
    }
}
