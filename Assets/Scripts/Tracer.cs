using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tracer : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float speed;
    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * speed;
    }
}
