using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public Transform[] moveSpots;
    public float speed = 2f;
    private int randomSpot;
    private Rigidbody2D rb;

    private Transform player;
    private float distance;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        randomSpot = Random.Range(0, moveSpots.Length);
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
            _Patrol();
        }

    }


    public void _Patrol()
    {
        transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f)
        {
            randomSpot = Random.Range(0, moveSpots.Length);
        }
    }
}
