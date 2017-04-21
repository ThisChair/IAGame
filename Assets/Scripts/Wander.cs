using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wander : MonoBehaviour {
    /*
     * This class implements "wander" behavior.
     * "Wander" makes the objects always move towards its current orientation, while rotating randomly.
     * Not all who wander are lost... But sure I am.
     */

    public float maxSpeed; // Max speed of the movement.
    public float maxRotation; // The maximum the object is allowed to randomly rotate.

    private Rigidbody rb; // Rigidbody of the wanderer.

    void Start()
    {
        rb = GetComponent<Rigidbody> ();
    }

    float randomBinomial()
    {
        return Random.value - Random.value;
    }

    void FixedUpdate()
    {
        rb.AddForce (transform.forward * maxSpeed);
        transform.Rotate(0,maxRotation * randomBinomial(),0);
    }
}
