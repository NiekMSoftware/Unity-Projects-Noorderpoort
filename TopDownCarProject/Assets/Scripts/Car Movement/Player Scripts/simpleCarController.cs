using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class simpleCarController : MonoBehaviour
{
    public WheelCollider[] wheels;

    public float motorPower;
    public float steerPower;
    public float playerDistance;

    public GameObject centerOfMass;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = centerOfMass.transform.localPosition;
    }

    private void FixedUpdate()
    {
        foreach (var wheel in wheels)
        {
            wheel.motorTorque = Input.GetAxis("Vertical") * ((motorPower * 5) / 4);
        }
        if (Input.GetAxis("Vertical") == 0)
        {
            rb.drag = 1;
            rb.angularDrag = 1;
        }
        else
        {
            rb.drag = 0;
            rb.angularDrag = 0;
        }
        for (int i = 0; i < wheels.Length; i++)
        {
            if (i < 2)
            {
                wheels[i].steerAngle = Input.GetAxis("Horizontal") * steerPower;
            }
        }
    }
}
