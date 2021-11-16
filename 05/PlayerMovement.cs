using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    
    public int speed;
    public int jumpForce;
    private Rigidbody2D rb;
    private bool isGrounded;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        isGrounded = true;
    }

    void Update() {
        float xDisplacement = Input.GetAxis("Horizontal");
        Vector3 displacementVector = new Vector3(xDisplacement, 0, 0);
        transform.Translate(displacementVector * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded) {
            isGrounded = false;
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.CompareTag("Ground")) {
            isGrounded = true;
        }
    }

    private void OnCollisionStay2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Ground")) {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Ground")) {
            isGrounded = false;
        }
    }
}
