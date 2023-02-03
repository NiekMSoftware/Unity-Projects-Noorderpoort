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
            /*
             * Add power going forward for the wheels
             */
            wheel.motorTorque = Input.GetAxis("Vertical") * ((motorPower * 5) / 4);
            
            /*
             * Apply a handbreak
             */
            if (Input.GetButton("Jump"))
            {
                rb.drag = 1;
                rb.angularDrag = 1;
            }
            
            //Disable handbreak
            if (!Input.GetButton("Jump"))
            {
                rb.drag = 0;
                rb.angularDrag = 0;
            }
        }
        
        /*
       * If there is no given input left
       */
        if (Input.GetAxis("Vertical") == 1 && !Input.GetButton("Jump"))
        {
            rb.drag = 0;
            rb.angularDrag = 0;
        }
        else
        {
            rb.drag = 0.5f;
            rb.angularDrag = 0.5f;
        }

        /*
         * Apply steering
         */
        for (int i = 0; i < wheels.Length; i++)
        {
            if (i < 2)
            {
                wheels[i].steerAngle = Input.GetAxis("Horizontal") * steerPower;
            }
        }
    }
}
