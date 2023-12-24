using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WeatherControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "RainyScene")
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
        else if (SceneManager.GetActiveScene().name == "SnowyScene")
        {
            transform.GetChild(1).gameObject.SetActive(true);
        }
    }
}
