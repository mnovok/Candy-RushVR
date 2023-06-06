using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gumball : MonoBehaviour
{
    Vector3 originalPosition;
    public LayerMask groundLayer;
    public GameObject gumball;

    void Start()
    {
        originalPosition = gumball.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((groundLayer.value & (1 << other.transform.gameObject.layer)) > 0)
        {
            gumball.transform.position = originalPosition;
        }
    }
}
