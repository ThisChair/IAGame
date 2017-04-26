using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Align : MonoBehaviour {

    public GameObject target; // The target to align with.
    public float maxAngularAcceleration; // Maximum angular acceleration.
    public float maxRotation; // Maximum angular speed.
    public float targetRadius; // Radius to arrive to the target.
    public float slowRadius; // Radius to begin to slow down.

    private float timeToTarget = 0.1f;
    private Rigidbody rb;

    void Start() {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float rotation = target.transform.eulerAngles.y - transform.eulerAngles.y;
        rotation %= 360.0f;
        if (Mathf.Abs (rotation) > 180) {
            if (rotation < 0.0f) {
                rotation += 360.0f;
            }
            if (rotation > 0.0f) {
                rotation -= 360.0f;
            }
        }
        float rotationSize = Mathf.Abs (rotation);

        if (rotationSize >= targetRadius) {
            float targetRotation;
            if (rotationSize > slowRadius) {
                targetRotation = maxRotation;
            } else {
                targetRotation = maxRotation * rotationSize / slowRadius;
            }
            targetRotation *= rotation / rotationSize;
            Rigidbody targetrb = target.GetComponent<Rigidbody> ();
            float angularAcceleration = targetRotation - targetrb.angularVelocity.y * Mathf.Rad2Deg;
            angularAcceleration /= timeToTarget;
            if (Mathf.Abs (angularAcceleration) > maxAngularAcceleration) {
                angularAcceleration = maxAngularAcceleration * Mathf.Sign (angularAcceleration);
            }
            rb.AddTorque (new Vector3 (0,angularAcceleration, 0));
        }
    }

}
