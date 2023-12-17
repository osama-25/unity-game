using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class AIcontrol : MonoBehaviour
{
    public Transform path;
    public float maxsteerangle = 30f;
    private float maxmotortorque = 130f;
    private float currentspeed;
    private float maxspeed = 150f;
    private float turnspeed = 5;
    private float targetsteerangle = 0;

    public WheelCollider FrontR;
    public WheelCollider FrontL;
    public WheelCollider BackR;
    public WheelCollider BackL;

    public Transform FrontRMesh;
    public Transform FrontLMesh;
    public Transform BackLMesh;
    public Transform BackRMesh;
    
    private List<Transform> nodes;
    private int currentnode = 0;
    void Start()
    {
        Transform[] pathtransforms = path.GetComponentsInChildren<Transform>();
        nodes = new List<Transform>();

        for(int i = 0; i < pathtransforms.Length; i++)
        {
            if (pathtransforms[i] != path.transform)
            {
                nodes.Add(pathtransforms[i]);
            }
        }
    }
    private void FixedUpdate()
    {
        ApplySteer();
        Drive();
        CheckWaypointDistance();
        LerpSteerAngle();
        RotateWheels();
    }
    private void ApplySteer()
    {
        Vector3 relativevector = transform.InverseTransformPoint(nodes[currentnode].position);
        float newSteer = (relativevector.x / relativevector.magnitude) * maxsteerangle;
        targetsteerangle = newSteer;
    }
    private void Drive()
    {
        currentspeed = 2 * Mathf.PI * FrontL.radius * FrontL.rpm * 60 / 1000;

        if (currentspeed < maxspeed)
        {
            BackR.motorTorque = maxmotortorque;
            BackL.motorTorque = maxmotortorque;
        }
        else
        {
            BackR.motorTorque = 0;
            BackL.motorTorque = 0;
        }
    }
    private void CheckWaypointDistance()
    {
        if (Vector3.Distance(transform.position, nodes[currentnode].position) < 1f)
        {
            //Debug.Log('d');
            if (currentnode == nodes.Count - 1)
            {
                currentnode = 0;
            }
            else
            {
                currentnode++;
            }
        }
        //Debug.Log(currentnode);
    }
    private void LerpSteerAngle()
    {
        FrontR.steerAngle = Mathf.Lerp(FrontR.steerAngle, targetsteerangle, Time.deltaTime * turnspeed);
        FrontL.steerAngle = Mathf.Lerp(FrontL.steerAngle, targetsteerangle, Time.deltaTime * turnspeed);
    }
    private void RotateWheels()
    {
        FrontLMesh.Rotate(0, 0, FrontL.rpm / 60 * 360 * Time.deltaTime);
        FrontRMesh.Rotate(0, 0, FrontR.rpm / 60 * 360 * Time.deltaTime);
        BackLMesh.Rotate(0, 0, BackL.rpm / 60 * 360 * Time.deltaTime);
        BackRMesh.Rotate(0, 0, BackR.rpm / 60 * 360 * Time.deltaTime);
    }
}
