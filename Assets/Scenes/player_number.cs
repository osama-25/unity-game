using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player_number : MonoBehaviour
{
    public int number;

    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "CasualScene")
        {
            if (number == 1)
            {
                transform.GetChild(11).GetComponent<Camera>().rect = new Rect(0, 0.5f, 1, 0.5f);
            }
            else if(number == 2)
            {
                transform.GetChild(11).GetComponent<Camera>().rect = new Rect(0, 0, 1, 0.5f);
            }
        }
    }
}
