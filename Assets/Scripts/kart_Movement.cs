using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kart_Movement : MonoBehaviour
{
    [SerializeField] WheelCollider frontright;
    [SerializeField] WheelCollider frontleft;
    [SerializeField] WheelCollider backright;
    [SerializeField] WheelCollider backleft;

    [SerializeField] Transform frontrighttransform;
    [SerializeField] Transform frontlefttransform;
    [SerializeField] Transform backrighttransform;
    [SerializeField] Transform backlefttransform;

    public float acceleration = 500f;
    public float breakingforce = 300f;
    public float maxturnangle = 30f;

    private float currentacceleration = 0f;
    private float currentbreakingforce = 0f;
    private float currentturnangle = 0f;

    

    private void FixedUpdate()
    {
        currentacceleration = acceleration * Input.GetAxis("Vertical");

        if(Input.GetKey(KeyCode.Space))
        {
            currentbreakingforce = breakingforce;
        }
        else
        {
            currentbreakingforce = 0f;
        }

        backright.motorTorque = currentacceleration;
        backleft.motorTorque = currentacceleration;

        frontright.brakeTorque = currentbreakingforce;
        frontleft.brakeTorque = currentbreakingforce;
        backright.brakeTorque = currentbreakingforce;
        backleft.brakeTorque = currentbreakingforce;

        currentturnangle = maxturnangle * Input.GetAxis("Horizontal");
        frontright.steerAngle = currentturnangle;
        frontleft.steerAngle = currentturnangle;

        UpdateWheel(frontright, frontrighttransform);
        UpdateWheel(frontleft, frontlefttransform);
        UpdateWheel(backright, backrighttransform);
        UpdateWheel(backleft, backlefttransform);

    }
    void UpdateWheel(WheelCollider wh, Transform tr)
    {
        Vector3 position;
        Quaternion rotation;
        wh.GetWorldPose(out position, out rotation);

        tr.position = position;
        tr.rotation = rotation;
    }
}
