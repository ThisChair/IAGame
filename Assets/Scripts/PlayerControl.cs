using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {
    /*
     * This class implements basic movement for the player object.
     * Information on the vertical axis is used to apply positive (up/w) or negative (down/s) force.
     * Information on the horizontal axis is used to apply positive (right/d) or negative (left/a) torque.
     * Note: This keys can be modified from the input manager.
     */

    public float force; // Magnitude of the thrust.
    public float torque; // Magnitude of the rotation.

    private Rigidbody rb; // Rigidbody of the player.

    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        // Make it so that the player won't budge by the sides when a force is applied.
        //rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
    }

    void FixedUpdate ()
    {
        float thrust = Input.GetAxis("Vertical");
        float turn = Input.GetAxis("Horizontal");
        rb.AddRelativeForce(Vector3.forward * thrust * force); // Take the value from the vertical input as a force.
        rb.AddRelativeTorque(Vector3.up * torque * turn); // Take the value from the horizontal input as a torque.
    }
}