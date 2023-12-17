using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lap : MonoBehaviour
{
    private int lapcount;
    public Text laptext;
    private bool checkflag = false;
    private void Start()
    {
        laptext = GameObject.FindGameObjectWithTag("canvas").transform.GetChild(0).GetChild(3).GetComponent<Text>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("lapback"))
        {
            checkflag = true;
        }
        if (other.CompareTag("lap") && checkflag)
        {
            lapcount++;
            laptext.text = $"Lap {lapcount}/2";
            if (lapcount == 3)
            {
                RaceManager.CheckWinner("player");
            }
        }
        else if (other.CompareTag("lap") && lapcount == 0)
        {
            lapcount++;
            laptext.text = $"Lap {lapcount}/2";
        }
    }
}
