using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    //for walking and running
    public float speed = 1f;
    //for jumping
    public int jumpForce;
    private bool isGrounded;
    //for dash
    public float dashSpeed;
    private float dashTime;
    public float startDashTime;
    private float dashDirection;
    private bool isDashing;
    //for trampoline
    public float upspeed;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isGrounded = true;
        dashTime = startDashTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
            speed = 2f;
        else
            speed = 1f;

        float xDisplacement = Input.GetAxis("Horizontal") * speed;
        Vector3 displacementVector = new Vector3(xDisplacement, 0, 0);
        transform.Translate(displacementVector * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isGrounded = false;
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }

        if (dashDirection == 0)
        {
            if (Input.GetKeyDown(KeyCode.Z))
                dashDirection = 1;
            else if (Input.GetKeyDown(KeyCode.X))
                dashDirection = 2;
        }
        else
        {
            if (dashTime <= 0)
            {
                dashDirection = 0;
                dashTime = startDashTime;
                rb.velocity = Vector2.zero;
            }
            else
            {
                dashTime -= Time.deltaTime;

                if (dashDirection == 1)
                    rb.velocity = Vector2.left * dashSpeed;
                else if (dashDirection == 2)
                    rb.velocity = Vector2.right * dashSpeed;
            }
        }
        if (isGrounded)
        {
            upspeed = 100f;
        }



       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Trampoline" && isGrounded == false) {
            upspeed += 50f;
            if (upspeed >= 650)
            {//tarmpoline
                upspeed = 650;
            }
            rb.AddForce(new Vector2(0, upspeed));

        }else if(collision.gameObject.tag == "Horizontal_Platform" && isGrounded == false)
        {
            isGrounded = true;
            transform.parent = collision.gameObject.transform;
        }
        else if (collision.gameObject.tag == "Vertical_Platform" && isGrounded == false)
        {
            isGrounded = true;
            transform.parent = collision.gameObject.transform;
        }
        else if (collision.rigidbody)
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Start")
        {//to destroy platform after leaving it
            Destroy(collision.gameObject);
            isGrounded = false;
        }else if (collision.gameObject.tag == "Horizontal_Platform")
        {
            transform.parent = null;
        }
        else if (collision.gameObject.tag == "Vertical_Platform")
        {
            transform.parent = null;
        }
        else if (collision.rigidbody)
        {
            isGrounded = false;
        }
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject, 2);
    }
}

