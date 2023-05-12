using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyTowardsTarget : MonoBehaviour
{
    public GameObject target;
    public float speed = 5.0f;

    private void Update()
    {
        if (target != null)
        {
            Vector3 direction = (target.transform.position - transform.position).normalized;

            // Rotate the missile to face the target
            transform.rotation = Quaternion.LookRotation(direction);

            transform.position += direction * speed * Time.deltaTime;
        }
    }
}

