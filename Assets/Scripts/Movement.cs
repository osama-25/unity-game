using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody RB;
    public GameObject Body;

    public Transform Wheel1;
    public Transform Wheel2;
    public Transform Wheel3;
    public Transform Wheel4;

    public Transform Right;
    public Transform Left;
    public Transform Straight;
    // Start is called before the first frame update
    void Start()
    {
        RB = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            RB.velocity += transform.right * 150 * Time.deltaTime;

            Wheel1.Rotate(-500 * Time.deltaTime, 0, 0);
            Wheel2.Rotate(-500 * Time.deltaTime, 0, 0);
            Wheel3.Rotate(500 * Time.deltaTime, 0, 0);
            Wheel4.Rotate(500 * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            RB.velocity -= transform.right * 80 * Time.deltaTime;

            Wheel1.Rotate(500 * Time.deltaTime, 0, 0);
            Wheel2.Rotate(500 * Time.deltaTime, 0, 0);
            Wheel3.Rotate(-500 * Time.deltaTime, 0, 0);
            Wheel4.Rotate(-500 * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W))
        {
            transform.Rotate(0, -30 *  Time.deltaTime, 0);
            Body.transform.rotation = Quaternion.Lerp(Body.transform.rotation, Left.rotation, 4 * Time.deltaTime);
            RB.velocity += Body.transform.forward * 120 * Time.deltaTime;
            RB.velocity -= transform.forward * 110 * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W))
        {
            transform.Rotate(0, 30 * Time.deltaTime, 0);
            Body.transform.rotation = Quaternion.Lerp(Body.transform.rotation, Right.rotation, 4 * Time.deltaTime);
            RB.velocity += Body.transform.forward * 120 * Time.deltaTime;
            RB.velocity -= transform.forward * 110 * Time.deltaTime;
        }
        if (!Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.W))
        {
            Body.transform.rotation = Quaternion.Lerp(Body.transform.rotation, Straight.rotation, 4 * Time.deltaTime);
        }
        if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.W))
        {
            Body.transform.rotation = Quaternion.Lerp(Body.transform.rotation, Straight.rotation, 4 * Time.deltaTime);
        }

    }
}
