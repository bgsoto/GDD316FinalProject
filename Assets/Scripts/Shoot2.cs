using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Shoot2 : MonoBehaviour


{
    public float rayLength = 10f;
    public Color rayColor = Color.red;
    [SerializeField] private GameObject enemy;
    [SerializeField] private float Rate_of_Fire = 0.162f;
    [SerializeField] private float currentRate;
    [SerializeField] private AudioClip machinegunsound;
    [SerializeField] private float ROF;
    [SerializeField] private TrailRenderer tracerEffect;
    [SerializeField] public ParticleSystem PS;
    [SerializeField] public Vector3 hitPoint;
    //private bool isTrailActive = false;

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
        
        Debug.DrawLine(transform.position, transform.position + transform.forward * 100f, Color.red, 1);

        if (Physics.Raycast(transform.position, transform.forward, out hit, rayLength))
        {
            Debug.Log(hit.transform.gameObject.name);
            // Visualize the raycast hit point
           // Debug.DrawLine(transform.position, hit.point, rayColor);

            //trailrenderer for tracer bullets
            trace();

            // hit particle
            hitPoint = hit.point;



            PS.transform.position = hit.point;
            PS.transform.LookAt(transform);
            PS.Play();



            //Debug.Log("hitpoint state");

            if (hit.collider.CompareTag("Enemy"))
            {
                targetHit();



                OnDeath();
                
                Destroy(hit.collider.gameObject);
            }
            // currentRate = 0.162f;
        }
        else
        {
            // Visualize the maximum raycast length
            Debug.DrawLine(transform.position, transform.position + transform.forward * rayLength, rayColor);
            trace();
            //  Debug.Log("length state");
            //tracer.transform.position = hit.point;
            //hitPoint = hit.point;

            //ParticleSystem.EmitParams eparams = new ParticleSystem.EmitParams();
            //eparams.position = hitPoint;

            //PS.Emit(eparams, 100);

            PS.transform.position = hit.point;
            PS.transform.rotation = Quaternion.Euler(hit.point - transform.position);
            PS.Play();
        }

        currentRate = 0.162f;
        GetComponentInChildren<AudioSource>().enabled = false;


    }

    void targetHit()
    {

        Debug.Log("TARGET HIT");


    }

    void trace()
    {
        TrailRenderer newTracer = Instantiate(tracerEffect);
        newTracer.transform.position = transform.position;
        newTracer.transform.rotation = transform.rotation;
    }
    
    void traceEnd()
    {

        //hitPoint = hit.point;

        ParticleSystem.EmitParams eparams = new ParticleSystem.EmitParams();
        eparams.position = hitPoint;

        PS.Emit(eparams, 100);

    }
    public void OnDeath()
    {
        // We find the GameManager object in the scene
        goal gameManager = FindObjectOfType<goal>();

        // Then we tell the GameManager that an enemy was killed
        gameManager.EnemyKilled();

     
    }


}