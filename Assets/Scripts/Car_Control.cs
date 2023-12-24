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

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = centreofmass.transform.localPosition;
    }

    void FixedUpdate()
    {
        //for tyre rotate
        WheelFLtrans.Rotate(0, 0, WheelFL.rpm / 60 * 360 * Time.deltaTime);
        WheelFRtrans.Rotate(0, 0, WheelFR.rpm / 60 * 360 * Time.deltaTime);
        WheelRLtrans.Rotate(0, 0, WheelRL.rpm / 60 * 360 * Time.deltaTime);
        WheelRRtrans.Rotate(0, 0, WheelRR.rpm / 60 * 360 * Time.deltaTime);

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

        WheelRR.motorTorque = maxTorque * Input.GetAxis("Vertical");
        WheelRL.motorTorque = maxTorque * Input.GetAxis("Vertical");

        float maxSteerAngle = 25.0f;
        float steeringSpeed = 2.0f;

        float targetSteerAngle = maxSteerAngle * Input.GetAxis("Horizontal");

        // Smoothly interpolate the current steering angle towards the target angle
        WheelFL.steerAngle = Mathf.Lerp(WheelFL.steerAngle, targetSteerAngle, Time.deltaTime * steeringSpeed);
        WheelFR.steerAngle = Mathf.Lerp(WheelFR.steerAngle, targetSteerAngle, Time.deltaTime * steeringSpeed);
    }
}
