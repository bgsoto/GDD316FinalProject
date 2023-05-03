using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Propeller : MonoBehaviour
{
    //Vector3 rotate;

    // Start is called before the first frame update

    [SerializeField] private Vector3 _roatation;


    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(_roatation * Time.deltaTime);
    }
}
