using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opponent : MonoBehaviour
{
    public float speed = 2;
    private Transform player;
    private Rigidbody2D rb;

    private float distance;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(player.position, rb.position);

        if (distance <= 6f)
        {

        }
        else
        {
            Move();
        }
    }

    void Move()
    {
        Vector2 target = new Vector2(player.position.x, rb.position.y);

        Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.deltaTime);

        rb.MovePosition(newPos);
    }
}

