using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour {
  
    public float delay;
    public GameObject cannonballPrefab;

    private Transform player;
    public bool isActive;
    public float rotationSpeed;


   


    void Start() {
        //Przypisanie komponentu Transform z obiektu gracza
        player = GameObject.FindGameObjectWithTag("Player").transform;
        
        isActive = false;

        

        GameEventSystem.Instance.OnPlayerInDangerZone += SetActive;
        //StartCoroutine(Shoot());
        
        
    }

    private void Update() {
        if (isActive) {

            
            //Wektor skierowany od armaty do obiektu gracza
            Vector3 direction = (player.position - transform.position).normalized;

            //Przekształcenia niezbędne do poprawnego obrotu w 2D
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);

            //Obracanie do docelowej rotacji z zadaną prędkością, aż do momentu osiągnięcia oczekiwanej wartości rotacji
            transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * rotationSpeed);

            
        }
    }

    public void SetActive(bool _isActive)
    {
        isActive = _isActive;
        if (isActive)
        {
            StartCoroutine(Shoot());

        }
        else {
            StopCoroutine(Shoot());
        }   
    }

    IEnumerator Shoot()
    {
        yield return new WaitForSeconds(delay);
        Instantiate(cannonballPrefab, transform.position, transform.rotation);
        yield return new WaitForSeconds(delay);
    }

}
