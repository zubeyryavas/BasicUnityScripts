using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannonball : MonoBehaviour {

    public int speed;
    private Rigidbody2D rb;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update() {
        Vector3 cannonballVector = transform.right * speed;
        rb.velocity = cannonballVector;
    }

    private void OnBecameInvisible() {
        Debug.Log("Poza ekranem");
        Destroy(gameObject, 2);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        Debug.Log("Kolizja");
        if (collision.gameObject.CompareTag("Player")) {
            Debug.Log("Kolizja z graczem");
            Destroy(collision.gameObject);
        }
    }
}
