using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AIcontrol : MonoBehaviour
{
    public Transform path;
    public float maxsteerangle = 30f;
    private float currentspeed;
    private float maxspeed = 150f;
    private float turnspeed = 5;
    private float targetsteerangle = 0;
    
    private float maxmotortorque;
    private float luigimotortorque = 120f;
    private float waluigimotortorque = 130f;
    private float wariomotortorque = 140f;

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
        // get path object from scene
        path = GameObject.FindGameObjectWithTag("Path").GetComponent<Transform>();

        Getspeed(); // change speed according to level

        // get all nodes in path and store them in nodes list
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
    private void Getspeed()
    {
        if (SceneManager.GetActiveScene().name == "RainyScene")
        {
            maxmotortorque = wariomotortorque;
        }
        else if (SceneManager.GetActiveScene().name == "NormalScene")
        {
            maxmotortorque = luigimotortorque;
        }
        else if (SceneManager.GetActiveScene().name == "SnowyScene")
        {
            maxmotortorque = waluigimotortorque;
        }
        else
        {
            maxmotortorque = waluigimotortorque;
        }
    }
    private void FixedUpdate()
    {
        ApplySteer(); // steer the wheel to next node
        Drive(); // move the car
        CheckWaypointDistance(); // check if distance between car and node is less than x then change to next node
        LerpSteerAngle(); // smooth car turns
        RotateWheels(); // rotate car mesh with wheel collider
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
        if (Vector3.Distance(transform.position, nodes[currentnode].position) < 5f)
        {
            if (currentnode == nodes.Count - 1)
            {
                currentnode = 0;
            }
            else
            {
                currentnode++;
            }
        }
    }
    private void LerpSteerAngle()
    {
        FrontR.steerAngle = Mathf.Lerp(FrontR.steerAngle, targetsteerangle, Time.deltaTime * turnspeed);
        FrontL.steerAngle = Mathf.Lerp(FrontL.steerAngle, targetsteerangle, Time.deltaTime * turnspeed);
    }
    private void RotateWheels()
    {
        FrontLMesh.Rotate(FrontL.rpm / 60 * 360 * Time.deltaTime, 0, 0);
        FrontRMesh.Rotate(FrontR.rpm / 60 * 360 * Time.deltaTime, 0, 0);
        BackLMesh.Rotate(BackL.rpm / 60 * 360 * Time.deltaTime, 0, 0);
        BackRMesh.Rotate(BackR.rpm / 60 * 360 * Time.deltaTime, 0, 0);
    }
}
