using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class DestroySelf : MonoBehaviour
{
    [SerializeField] private float tracelife = 0.5f;
    void Start()
    {
        StartCoroutine(DestroyAfterDelay(tracelife));
    }

    IEnumerator DestroyAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}
