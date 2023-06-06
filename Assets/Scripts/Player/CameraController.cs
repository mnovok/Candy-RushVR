using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] Transform target;
    private Vector3 offset;
    [SerializeField] Transform rig;

    public float smoothSpeed = 0.15f;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        rig = GameObject.FindGameObjectWithTag("Rig").transform;
        offset = transform.position - target.position;
    }

    void Update()
    {
       transform.position = target.position + offset;
        //Vector3 desiredPosition = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, (target.position + offset), smoothSpeed);


    }
}
