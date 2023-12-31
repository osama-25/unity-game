using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlaceCar : MonoBehaviour
{
    public static GameObject Car, Car2;
    public Transform carpos, carpos2;

    public Transform aicarpos, aicarpos2;
    public GameObject ailuigi, aiwaluigi, aiwario;
    private void Awake()
    {
        if (SceneManager.GetActiveScene().name == "NormalScene")
        {
            GameObject clone = Instantiate(ailuigi);
            clone.transform.position = aicarpos.position;

            clone = Instantiate(Car);
            clone.transform.position = carpos.position;
            GameObject.FindGameObjectWithTag("cameras").transform.GetChild(0).GetComponent<CinemachineVirtualCamera>().Follow = clone.transform;
            GameObject.FindGameObjectWithTag("cameras").transform.GetChild(0).GetComponent<CinemachineVirtualCamera>().LookAt = clone.transform;
        }
        else if (SceneManager.GetActiveScene().name == "SnowyScene")
        {
            GameObject clone = Instantiate(aiwaluigi);
            clone.transform.position = aicarpos.position;

            clone = Instantiate(Car);
            clone.transform.position = carpos.position;
            GameObject.FindGameObjectWithTag("cameras").transform.GetChild(0).GetComponent<CinemachineVirtualCamera>().Follow = clone.transform;
            GameObject.FindGameObjectWithTag("cameras").transform.GetChild(0).GetComponent<CinemachineVirtualCamera>().LookAt = clone.transform;
        }
        else if (SceneManager.GetActiveScene().name == "RainyScene")
        {
            GameObject clone = Instantiate(aiwario);
            clone.transform.position = aicarpos.position;

            clone = Instantiate(Car);
            clone.transform.position = carpos.position;
            GameObject.FindGameObjectWithTag("cameras").transform.GetChild(0).GetComponent<CinemachineVirtualCamera>().Follow = clone.transform;
            GameObject.FindGameObjectWithTag("cameras").transform.GetChild(0).GetComponent<CinemachineVirtualCamera>().LookAt = clone.transform;
        }
        else if (SceneManager.GetActiveScene().name == "CasualScene")
        {
            GameObject clone = Instantiate(aiwario);
            clone.transform.position = aicarpos.position;
            clone = Instantiate(aiwaluigi);
            clone.transform.position = aicarpos2.position;

            clone = Instantiate(Car);
            clone.transform.position = carpos.position;
            clone.GetComponent<player_number>().number = 1;
            clone = Instantiate(Car2);
            clone.transform.position = carpos2.position;
            clone.GetComponent<player_number>().number = 2;
        }
    }
}
