using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Lap : MonoBehaviour
{
    private int lapcount;
    public Text laptext;
    private bool checkflag = false;
    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "CasualScene")
        {
            if (gameObject.GetComponent<player_number>().number == 1)
            {
                laptext = GameObject.FindGameObjectWithTag("canvas").transform.GetChild(0).GetChild(0).GetChild(3).GetComponent<Text>();
            }
            else
            {
                laptext = GameObject.FindGameObjectWithTag("canvas").transform.GetChild(1).GetChild(0).GetChild(3).GetComponent<Text>();
            }
        }
        else
        {
            laptext = GameObject.FindGameObjectWithTag("canvas").transform.GetChild(0).GetChild(3).GetComponent<Text>();
        }
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
                if (SceneManager.GetActiveScene().name == "CasualScene")
                {
                    if (gameObject.GetComponent<player_number>().number == 1)
                    {
                        CasualRaceManager.finishpos++;
                        CasualRaceManager.FinishRace1();
                    }
                    else
                    {
                        CasualRaceManager.finishpos++;
                        CasualRaceManager.FinishRace2();
                    }
                }
                else
                {
                    RaceManager.CheckWinner("player");
                }
            }
        }
        else if (other.CompareTag("lap") && lapcount == 0)
        {
            lapcount++;
            laptext.text = $"Lap {lapcount}/2";
        }
    }
}
