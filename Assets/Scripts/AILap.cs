using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AILap : MonoBehaviour
{
    private int lapcount;
    private bool checkflag = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("lapback"))
        {
            checkflag = true;
        }
        if (other.CompareTag("lap") && checkflag)
        {
            lapcount++;
            if (lapcount == 3)
            {
                stopcar();
                RaceManager.CheckWinner("ai");
            }
        }
        else if (other.CompareTag("lap") && lapcount == 0)
        {
            lapcount++;
        }
    }
    void stopcar()
    {
        gameObject.GetComponent<AIcontrol>().enabled = false;
        Vector3 currentVelocity = gameObject.GetComponent<Rigidbody>().velocity;
        Vector3 decelerationForce = -currentVelocity.normalized * 20;
        gameObject.GetComponent<Rigidbody>().AddForce(decelerationForce, ForceMode.Acceleration);
    }
}
