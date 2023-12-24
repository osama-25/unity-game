using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class RaceManager : MonoBehaviour
{
    public static int playercheckpoint = 0, aicheckpoint = 0;
    public static Text postext;

    public static AILap ailap;
    public static Lap lap;
    public static bool flag = true;

    public static Text resulttext, first, second;
    public static GameObject finishscene;
    private void Start()
    {
        finishscene = GameObject.FindGameObjectWithTag("cameras").transform.GetChild(1).gameObject;
        postext = GameObject.FindGameObjectWithTag("canvas").transform.GetChild(0).GetChild(4).GetComponent<Text>();
        ailap = GameObject.FindGameObjectWithTag("AIPlayer").GetComponent<AILap>();
        lap = GameObject.FindGameObjectWithTag("Player").GetComponent<Lap>();
        resulttext = GameObject.FindGameObjectWithTag("canvas").transform.GetChild(1).GetChild(0).GetComponent<Text>();
        first = GameObject.FindGameObjectWithTag("canvas").transform.GetChild(1).GetChild(1).GetComponent<Text>();
        second = GameObject.FindGameObjectWithTag("canvas").transform.GetChild(1).GetChild(2).GetComponent<Text>();
    }
    public static void ChangePos()
    {
        postext.text = "Pos " + (playercheckpoint >= aicheckpoint? 1 : 2) + "/2";
    }
    public static void CheckWinner(string winner)
    {
        if (flag)
        {
            flag = false;
            changetext();
            finishscene.SetActive(true);
            if (winner == "ai")
            {
                setcamera("ai");
                finishscene.transform.GetChild(3).gameObject.SetActive(true);
                resulttext.text = "You Lost";
                resulttext.color = Color.red;
                first.text = "1- " + GameObject.FindGameObjectWithTag("AIPlayer").name;
                second.text = "2- " + GameObject.FindGameObjectWithTag("Player").name + " (You)";
            }
            else if (winner == "player")
            {
                setcamera("you");
                finishscene.transform.GetChild(2).gameObject.SetActive(true);
                resulttext.text = "You Won";
                first.text = "1- " + GameObject.FindGameObjectWithTag("Player").name + " (You)";
                second.text = "2- " + GameObject.FindGameObjectWithTag("AIPlayer").name;
            }
        }
    }
    static void changetext()
    {
        GameObject.FindGameObjectWithTag("canvas").transform.GetChild(0).gameObject.SetActive(false);
        GameObject.FindGameObjectWithTag("canvas").transform.GetChild(1).gameObject.SetActive(true);
    }
    static void setcamera(string winner)
    {
        if (winner == "you")
        {
            finishscene.transform.GetChild(5).GetComponent<CinemachineVirtualCamera>().LookAt = GameObject.FindGameObjectWithTag("Player").transform;
        }
        else
        {
            finishscene.transform.GetChild(1).GetComponent<CinemachineVirtualCamera>().LookAt = GameObject.FindGameObjectWithTag("AIPlayer").transform;
        }
    }
}
