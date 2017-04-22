using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookWhereYoureGoing : MonoBehaviour {
    /* This class implements "LookWhereYoureGoing" behaviour.
     * LookWhereYoureGoing takes the object's velocity direction orientates it
     * in that direction.
     */


    private Rigidbody rb; // Rigidbody of the seeker.

    void Start ()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate ()
    {
        Vector3 spd = rb.velocity;
        if (spd.sqrMagnitude > 0) {
            // Make the object look in the direction of movement.
            transform.LookAt (new Vector3(spd.x, transform.position.y, spd.z), Vector3.up);
        }
    }
}
