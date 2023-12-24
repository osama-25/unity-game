using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startgame : MonoBehaviour
{
    private GameObject[] cars;
    private GameObject[] aicars;
    private void Start()
    {
        cars = GameObject.FindGameObjectsWithTag("Player");
        aicars = GameObject.FindGameObjectsWithTag("AIPlayer");
    }
    public void show()
    {
        foreach(GameObject aicar in aicars)
        {
            aicar.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            aicar.GetComponent<AIcontrol>().enabled = true;
        }
        foreach(GameObject car in cars)
        {
            car.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            car.GetComponent<Car_Control>().enabled = true;
            car.GetComponent<Boost>().enabled = true;
        }
        transform.GetChild(0).gameObject.SetActive(true);
    }
}
