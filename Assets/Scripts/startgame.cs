using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            if (SceneManager.GetActiveScene().name == "RainyScene")
            {
                aicar.transform.GetChild(11).gameObject.SetActive(true);
            }
        }
        foreach(GameObject car in cars)
        {
            car.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            car.GetComponent<Car_Control>().enabled = true;
            car.GetComponent<Boost>().enabled = true;
            if (SceneManager.GetActiveScene().name == "CasualScene")
            {
                car.transform.GetChild(11).gameObject.SetActive(true);
            }
        }
        transform.GetChild(0).gameObject.SetActive(true);
        if (SceneManager.GetActiveScene().name == "CasualScene")
        {
            transform.GetChild(1).gameObject.SetActive(true);
        }
    }
    public void PauseGame()
    {
        foreach (GameObject car in cars)
        {
            car.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            car.GetComponent<Car_Control>().enabled = false;
            car.GetComponent<Boost>().enabled = false;
        }
        foreach (GameObject aicar in aicars)
        {
            aicar.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            aicar.GetComponent<AIcontrol>().enabled = false;
        }
        if (SceneManager.GetActiveScene().name == "CasualScene")
        {
            GameObject.FindGameObjectWithTag("canvas").transform.GetChild(1).gameObject.SetActive(false);
        }
        GameObject.FindGameObjectWithTag("canvas").transform.GetChild(0).gameObject.SetActive(false);
        GameObject.FindGameObjectWithTag("canvas").transform.GetChild(2).gameObject.SetActive(true);
    }
    public void ResumeGame()
    {
        foreach (GameObject car in cars)
        {
            car.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            car.GetComponent<Car_Control>().enabled = true;
            car.GetComponent<Boost>().enabled = true;
        }
        foreach (GameObject aicar in aicars)
        {
            aicar.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            aicar.GetComponent<AIcontrol>().enabled = true;
        }
        if (SceneManager.GetActiveScene().name == "CasualScene")
        {
            GameObject.FindGameObjectWithTag("canvas").transform.GetChild(1).gameObject.SetActive(true);
        }
        GameObject.FindGameObjectWithTag("canvas").transform.GetChild(0).gameObject.SetActive(true);
        GameObject.FindGameObjectWithTag("canvas").transform.GetChild(2).gameObject.SetActive(false);
    }
    public void ExitGame()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
