using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seek : MonoBehaviour {
    /*
     * This class implements "seek" behavior.
     * "Seek" uses a target object as an input, and takes its position to 
     */ 


    public GameObject target; // Target object to seek.
    public float maxSpeed; // Max speed of the movement towards the target.

    private Rigidbody rb; // Rigidbody of the seeker.

    void Start ()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate ()
    {
        // Get the direction to the target object.
        Transform seeker = GetComponent<Transform>();
        Vector3 direction = (target.transform.position - seeker.position).normalized;
        rb.AddForce(direction * maxSpeed);
    }


}
