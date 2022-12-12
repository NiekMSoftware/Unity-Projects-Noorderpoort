using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIRemoteController : MonoBehaviour
{
   [SerializeField] private Transform targetPositionTransform;

    public float horizontalInput;
    public float verticalInput;
    public float currentBrakeForce;
    public float steerAngle;
    public bool isEBraking;
    public bool isBraking;

    PlayerRemoteControl playerRemoteControl;

    [Header("Driving")]
    [SerializeField] public float motorForce;
    [SerializeField] public float breakForce;
    [SerializeField] public float EbreakForce;
    [SerializeField] public float maxSteeringAngle;
    //[SerializeField] private TextMeshProUGUI speedText;

    [SerializeField] public WheelCollider frontLeftWheelCollider;
    [SerializeField] public WheelCollider frontRightWheelCollider;
    [SerializeField] public WheelCollider backLeftWheelCollider;
    [SerializeField] public WheelCollider backRightWheelCollider;

    [SerializeField] public Transform frontLeftWheelTransform;
    [SerializeField] public Transform frontRightWheelTransform;
    [SerializeField] public Transform backLeftWheelTransform;
    [SerializeField] public Transform backRightWheelTransform;

    [Header("Other")]
    //[SerializeField] private GroundCheck groundCheck;
    //[SerializeField] private CheckPointManager checkPointManager;


    public Rigidbody rb;

    VroomVroomController basicCarController;
    

    private void Awake()
    {
        basicCarController = GetComponent<VroomVroomController>();
        rb = GetComponent<Rigidbody>();
        playerRemoteControl = GetComponent<PlayerRemoteControl>();
    }
    private void Start()
    {
        rb.centerOfMass += new Vector3(0f, -1.5f, 0f);
    }

    void FixedUpdate()
    {
        Vector3 targetPosition = targetPositionTransform.position;
        float forwards = 0;
        float turn = 0;

        Vector3 directionToTarget = (targetPosition - transform.position);
        float dot = Vector3.Dot(transform.forward, directionToTarget);

        float distance = Vector3.Distance(transform.position, targetPosition);
        float minDistance = 2;

        if (distance > minDistance)
        {

            if (dot > 0)
            {
                forwards = 1;
            }
            else if (dot < 0)
            {
                forwards = -1;
            }

            float angle = Vector3.SignedAngle(transform.forward, directionToTarget, Vector3.up);

            if (angle > 5)
            {
                turn = 1;
            }
            else if (angle < -5)
            {
                turn = -1;
            }
        } else {
            targetPositionTransform = basicCarController.NextCheckPoint().transform;
        }

        basicCarController.motorForce = forwards;
        basicCarController.maxSteeringAngle = turn;

        //User Input

        //verticalInput = Input.actions["Throttle"].ReadValue<float>();
        //horizontalInput = input.actions["Steering"].ReadValue<float>();
        //isEBraking = input.actions["HandBrake"].ReadValue<float>();


        //verticalInput = Input.GetAxis("Vertical");
        //horizontalInput = Input.GetAxis("Horizontal");
        //isEBraking = Input.GetKey(KeyCode.Space);

        //Driving Forward
        if (verticalInput > 0)
        {
            isBraking = false;
            frontLeftWheelCollider.motorTorque = verticalInput * motorForce;
            frontRightWheelCollider.motorTorque = verticalInput * motorForce;
            backLeftWheelCollider.motorTorque = verticalInput * motorForce;
            backRightWheelCollider.motorTorque = verticalInput * motorForce;
            rb.drag = 0;
            rb.angularDrag = 0;
        }
        else if (verticalInput < 0)
        {
            if (rb.velocity.z < 0.01f)
            {
                //Reversing
                isBraking = false;
                frontLeftWheelCollider.motorTorque = verticalInput * motorForce;
                frontRightWheelCollider.motorTorque = verticalInput * motorForce;
                backLeftWheelCollider.motorTorque = verticalInput * motorForce;
                backRightWheelCollider.motorTorque = verticalInput * motorForce;
                rb.drag = 0;
                rb.angularDrag = 0;
            }
            else
            {
                //Braking
                isBraking = true;
                frontRightWheelCollider.brakeTorque = breakForce;
                frontLeftWheelCollider.brakeTorque = breakForce;
                backRightWheelCollider.brakeTorque = breakForce;
                backLeftWheelCollider.brakeTorque = breakForce;
                rb.drag = Mathf.Lerp(rb.drag, 0.5f, 0.3f * Time.deltaTime);
                rb.angularDrag = Mathf.Lerp(rb.angularDrag, 0.5f, 0.3f * Time.deltaTime);
            }
        }
        else
        {
            frontLeftWheelCollider.motorTorque = 0;
            frontRightWheelCollider.motorTorque = 0;
            backLeftWheelCollider.motorTorque = 0;
            backRightWheelCollider.motorTorque = 0;
            frontLeftWheelCollider.brakeTorque = 0;
            frontRightWheelCollider.brakeTorque = 0;
            backLeftWheelCollider.brakeTorque = 0;
            backRightWheelCollider.brakeTorque = 0;
            rb.drag = Mathf.Lerp(rb.drag, 0.5f, 0.3f * Time.deltaTime);
            rb.angularDrag = Mathf.Lerp(rb.angularDrag, 0.5f, 0.3f * Time.deltaTime);
        }

        //EBraking
        if (!isBraking)
        {
            currentBrakeForce = isEBraking ? EbreakForce : 0;
            frontRightWheelCollider.brakeTorque = currentBrakeForce;
            frontLeftWheelCollider.brakeTorque = currentBrakeForce;
            backLeftWheelCollider.brakeTorque = currentBrakeForce;
            backRightWheelCollider.brakeTorque = currentBrakeForce;
        }

        //Steering
        steerAngle = maxSteeringAngle * horizontalInput;
        frontLeftWheelCollider.steerAngle = steerAngle;
        frontRightWheelCollider.steerAngle = steerAngle;

        //Visualize Steering
        //UpdateWheel(frontLeftWheelCollider, frontLeftWheelTransform);
        //UpdateWheel(frontRightWheelCollider, frontRightWheelTransform);
        //UpdateWheel(backLeftWheelCollider, backLeftWheelTransform);
        //UpdateWheel(backRightWheelCollider, backRightWheelTransform);
    }
    private void Update()
    {
        //if (Vector3.Distance(checkPointManager.GetCurrentCheckPoint().transform.position, transform.position) <= 2f)
        //{
        //    checkPointManager.SetCheckPointNum();
        //}

        //speedText.text = Mathf.Round(rb.velocity.magnitude * 3.6f) + "KM/H";

        //Flip Car
        //if (!groundCheck.IsGrounded() && rb.velocity.magnitude < 1 && Input.GetKeyDown(KeyCode.R))
        //{
        //    transform.rotation = Quaternion.identity;
        //}
    }

    

    private void UpdateWheel(WheelCollider wheelCollider, Transform wheelTransform)
    {
        Vector3 pos;
        Quaternion rot;
        wheelCollider.GetWorldPose(out pos, out rot);
        wheelTransform.rotation = Quaternion.Lerp(wheelTransform.rotation, rot, Time.deltaTime * 2);
        wheelTransform.position = pos;
        wheelTransform.position = Vector3.Lerp(wheelTransform.position, pos, Time.deltaTime * 2);
    }
}