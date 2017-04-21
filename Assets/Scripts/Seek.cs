using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seek : MonoBehaviour {
    /*
     * This class implements "seek" behavior.
     * "Seek" uses a target object as an input, and takes its position relative to this object
     * as a direction to apply a force
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
        if (!direction.Equals(Vector3.zero)) {
            // Make the object look in the direction of movement.
            transform.LookAt (new Vector3(direction.x, seeker.position.y, direction.z), Vector3.up);
            // Push toward the target.
            rb.AddForce (direction * maxSpeed);
        }
    }


}