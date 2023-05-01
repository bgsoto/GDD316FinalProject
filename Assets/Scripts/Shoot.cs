using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Shoot : MonoBehaviour


{
    public float rayLength = 10f;
    public Color rayColor = Color.red;
    [SerializeField] private GameObject enemy;
    [SerializeField] private float Rate_of_Fire = 0.162f;
    [SerializeField] private float currentRate;
    [SerializeField] private AudioClip machinegunsound;
    [SerializeField] private float ROF;
    [SerializeField] private TrailRenderer tracerEffect;
    private bool isTrailActive = false;

    private void Start()
    {

        Rate_of_Fire = currentRate;


    }



    private void Update()
    {
       

        if (Input.GetMouseButton(0))
        {
            // Debug.Log("mouse button clicked");
            currentRate -= Time.deltaTime;

            if (currentRate <= 0.162f - ROF)
            {
                shoot();
                GetComponentInChildren<AudioSource>().enabled = true;
            }


            //Rate_of_Fire = 0.162f;
            //currentRate = 0.162f;
            //GetComponent<AudioSource>().enabled = false;
        }
       
        
    }
    void shoot()
    {
        //Debug.Log("shoot");
        
        RaycastHit hit;


       // var tracer = Instantiate(tracerEffect,hit.point, Quaternion.identity);
        //tracer.AddPosition(hit.point);


        if (Physics.Raycast(transform.position, transform.forward, out hit, rayLength))
        {
            // Visualize the raycast hit point
            Debug.DrawLine(transform.position, hit.point, rayColor);

            //tracer.transform.position = hit.point;

            //Debug.Log("hitpoint state");

            if (hit.collider.CompareTag("Enemy") )
            {
                targetHit();
            }
           // currentRate = 0.162f;
        }
        else
        {
            // Visualize the maximum raycast length
            Debug.DrawLine(transform.position, transform.position + transform.forward * rayLength, rayColor);
            //  Debug.Log("length state");
            //tracer.transform.position = hit.point;
        }
        
        currentRate = 0.162f;
       GetComponentInChildren<AudioSource>().enabled = false;
           
      
    }

    void targetHit()
    {
        
        Debug.Log("TARGET HIT");


    }
}
