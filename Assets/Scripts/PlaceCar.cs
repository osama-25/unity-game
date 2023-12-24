using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlaceCar : MonoBehaviour
{
    public Transform aicarpos;
    public GameObject ailuigi, aiwaluigi, aiwario;
    private void Awake()
    {
        if (SceneManager.GetActiveScene().name == "NormalScene")
        {
            GameObject clone = Instantiate(ailuigi);
            clone.transform.position = aicarpos.position;
        }
        else if (SceneManager.GetActiveScene().name == "SnowyScene")
        {
            GameObject clone = Instantiate(aiwaluigi);
            clone.transform.position = aicarpos.position;
        }
        else if (SceneManager.GetActiveScene().name == "RainyScene")
        {
            GameObject clone = Instantiate(aiwario);
            clone.transform.position = aicarpos.position;
        }
    }
}
