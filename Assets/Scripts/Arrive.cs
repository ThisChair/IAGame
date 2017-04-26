using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrive : MonoBehaviour {
    /*
     * This class implements "arrive" behaviour.
     * "Arrive" uses a target object as an input, and takes its position relative to this object
     * as a direction to apply a force, until slow doing upon reaching a radius, and halting
     * at a fixed distance from the target.
     */ 


    public GameObject target; // Target object to seek.
    public float maxAcceleration; // Max speed of the movement towards the target.
    public float maxSpeed; // Max speed of the movement towards the target.
    public float targetRadius;
    public float slowRadius;
    public float timeToTarget = 0.1f;

    private Rigidbody rb; // Rigidbody of the seeker.

    void Start ()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate ()
    {
        // Get the direction to the target object.
        Transform seeker = GetComponent<Transform>();
        Vector3 direction = (target.transform.position - seeker.position);
        float distance = direction.magnitude;
        if (distance >= targetRadius) {
            float targetSpeed = 0.0f;
            if (distance > slowRadius) {
                targetSpeed = maxSpeed;
            }
            else {
                targetSpeed = maxSpeed * distance / slowRadius;
            }
            Vector3 targetVelocity = direction.normalized * targetSpeed;

            Rigidbody targetrb = target.GetComponent<Rigidbody> ();

            Vector3 acceleration = (targetVelocity - targetrb.velocity)/timeToTarget;

            if (acceleration.magnitude > maxAcceleration) {
                acceleration = acceleration.normalized * maxAcceleration;
            }

            // Push toward the target.
            rb.AddForce (acceleration);
        }
    }
}
