﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flee : MonoBehaviour {
    /*
     * This class implements "flee" behavior.
     * "Flee" uses a target object as an input, and takes its position relative to this object
     * and applies a force inverse to a direction.
     */ 


    public GameObject target; // Target object to seek.
    public float maxSpeed; // Max speed of the movement towards the target.

    private Rigidbody rb; // Rigidbody of the fleeing object.

    void Start ()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate ()
    {
        // Get the direction away from the target object.
        Transform seeker = GetComponent<Transform>();
        Vector3 direction = (seeker.position -  target.transform.position).normalized;
        if (!direction.Equals (Vector3.zero)) {
            // Make the object look in the direction of movement.
            transform.LookAt (new Vector3 (direction.x, seeker.position.y, direction.z), Vector3.up);
            // Push away from the target.
            rb.AddForce (direction * maxSpeed);
        }
    }


}