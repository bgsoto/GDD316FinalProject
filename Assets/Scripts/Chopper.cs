using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Chopper : MonoBehaviour
{
    public float radius = 10f;
    public float speed = 2f;

    private Vector3 center;
    private float angle = 0f;

    private void Start()
    {
        center = transform.position;
    }

    private void Update()
    {
        angle += speed * Time.deltaTime;
        float x = Mathf.Sin(angle) * radius;
        float z = Mathf.Cos(angle) * radius;
        Vector3 newPosition = center + new Vector3(x, 0f, z);
        transform.position = newPosition;
        transform.rotation = Quaternion.LookRotation(center - newPosition);
    }
}

