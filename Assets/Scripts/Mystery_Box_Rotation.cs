using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mystery_Box_Rotation : MonoBehaviour
{
    public Vector3 rotateamount;
    public Vector3 movementamount;

    public Vector3 firstposition;
    // Start is called before the first frame update
    void Start()
    {
        firstposition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= firstposition.y - 0.75 || transform.position.y >= firstposition.y)
        {
            movementamount = -movementamount;
        }
        transform.Translate(movementamount * Time.deltaTime);
        transform.Rotate(rotateamount * Time.deltaTime);
    }
}
