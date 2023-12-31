using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class Car_Control : MonoBehaviour
{
    public WheelCollider WheelFL;
    public WheelCollider WheelFR;
    public WheelCollider WheelRL;
    public WheelCollider WheelRR;

    public Transform WheelFLtrans;
    public Transform WheelFRtrans;
    public Transform WheelRLtrans;
    public Transform WheelRRtrans;

    public Vector3 eulertest;

    private Rigidbody rb;
    public Transform centreofmass;
    public float maxTorque = 200;

    private float horizontalaxis;
    private float verticalaxis;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = centreofmass.transform.localPosition;
    }

    void FixedUpdate()
    {
        if (gameObject.GetComponent<player_number>().number == 2)
        {
            horizontalaxis = Input.GetAxis("Horizontal2");
            verticalaxis = Input.GetAxis("Vertical2");
        }
        else
        {
            horizontalaxis = Input.GetAxis("Horizontal");
            verticalaxis = Input.GetAxis("Vertical");
        }
        //for tyre rotate
        WheelFLtrans.Rotate(WheelFL.rpm / 60 * 360 * Time.deltaTime, 0, 0);
        WheelFRtrans.Rotate(WheelFR.rpm / 60 * 360 * Time.deltaTime, 0, 0);
        WheelRLtrans.Rotate(WheelRL.rpm / 60 * 360 * Time.deltaTime, 0, 0);
        WheelRRtrans.Rotate(WheelRR.rpm / 60 * 360 * Time.deltaTime, 0, 0);

        Vector3 temp = WheelFLtrans.localEulerAngles;
        Vector3 temp1 = WheelFRtrans.localEulerAngles;

        // Account for initial rotation offset of the tire mesh
        float initialRotationOffset = 90f;

        temp.y = WheelFL.steerAngle - initialRotationOffset;
        WheelFLtrans.localEulerAngles = temp;

        temp1.y = WheelFR.steerAngle + initialRotationOffset;
        WheelFRtrans.localEulerAngles = temp1;

        // Additional Debug
        eulertest = WheelFLtrans.localEulerAngles;
        //speed of car, Car will move as you will provide the input to it.

        WheelRR.motorTorque = maxTorque * verticalaxis;
        WheelRL.motorTorque = maxTorque * verticalaxis;

        float maxSteerAngle = 25.0f;
        float steeringSpeed = 2.0f;

        float targetSteerAngle = maxSteerAngle * horizontalaxis;

        // Smoothly interpolate the current steering angle towards the target angle
        WheelFL.steerAngle = Mathf.Lerp(WheelFL.steerAngle, targetSteerAngle, Time.deltaTime * steeringSpeed);
        WheelFR.steerAngle = Mathf.Lerp(WheelFR.steerAngle, targetSteerAngle, Time.deltaTime * steeringSpeed);
    }
}
