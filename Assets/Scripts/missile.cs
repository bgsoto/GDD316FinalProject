using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class missile : MonoBehaviour
{
    public float speed = 5.0f;
    public GameObject target;
    private Rigidbody rb;

    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        if (target == null)
        {
            Debug.Log("Target not assigned. Please assign a target GameObject.");
        }
    }

    void FixedUpdate()
    {
        if (target != null)
        {
            Vector3 direction = (target.transform.position - transform.position).normalized;
            rb.velocity = direction * speed;
            transform.LookAt(target.transform);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == target)
        {
            Destroy(target);
            Destroy(gameObject);
        }
    }
}





