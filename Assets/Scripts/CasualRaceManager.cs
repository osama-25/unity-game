using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CasualRaceManager : MonoBehaviour
{
    public static int player1checkpoint = 0, ai1checkpoint = 0, player2checkpoint = 0, ai2checkpoint = 0;
    public static Text postext1, postext2;

    public static bool flag = true, flag2 = true;

    public static Text pos1, pos2;
    public static GameObject finishscene;

    public static int finishpos = 0;

    public static GameObject player1, player2;
    private void Start()
    {
        foreach (GameObject car in GameObject.FindGameObjectsWithTag("Player"))
        {
            if (car.GetComponent<player_number>().number == 1)
            {
                player1 = car;
            }
            else if (car.GetComponent<player_number>().number == 2)
            {
                player2 = car;
            }
        }
        finishscene = GameObject.FindGameObjectWithTag("cameras").transform.GetChild(0).gameObject;
        postext1 = GameObject.FindGameObjectWithTag("canvas").transform.GetChild(0).GetChild(0).GetChild(4).GetComponent<Text>();
        postext2 = GameObject.FindGameObjectWithTag("canvas").transform.GetChild(1).GetChild(0).GetChild(4).GetComponent<Text>();
        pos1 = GameObject.FindGameObjectWithTag("canvas").transform.GetChild(0).GetChild(1).GetChild(1).GetComponent<Text>();
        pos2 = GameObject.FindGameObjectWithTag("canvas").transform.GetChild(1).GetChild(1).GetChild(1).GetComponent<Text>();
    }
    public static void ChangePos()
    {
        int[] values = { player1checkpoint, player2checkpoint, ai1checkpoint, ai2checkpoint};

        var orderedValues = values.OrderByDescending(x => x).ToArray();
        for(int i = 0; i < 4; i++)
        {
            if (orderedValues[i] == player1checkpoint)
            {
                postext1.text = "Pos " + (i + 1) + "/4";
            }
            else if (orderedValues[i] == player2checkpoint)
            {
                postext2.text = "Pos " + (i + 1) + "/4";
            }
        }
    }
    public static void FinishRace1()
    {
        if (flag)
        {
            flag = false;
            changetext1();
            finishscene.SetActive(true);
            pos1.text = "Position - " + finishpos;
            setcamera(1);
            finishscene.transform.GetChild(2).gameObject.SetActive(true);
        }
    }
    public static void FinishRace2()
    {
        if (flag2)
        {
            flag2 = false;
            changetext2();
            finishscene.SetActive(true);
            pos2.text = "Position - " + finishpos;
            setcamera(2);
            finishscene.transform.GetChild(2).gameObject.SetActive(true);
        }
    }

    static void changetext1()
    {
        GameObject.FindGameObjectWithTag("canvas").transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
        GameObject.FindGameObjectWithTag("canvas").transform.GetChild(0).GetChild(1).gameObject.SetActive(true);
    }
    static void changetext2()
    {
        GameObject.FindGameObjectWithTag("canvas").transform.GetChild(1).GetChild(0).gameObject.SetActive(false);
        GameObject.FindGameObjectWithTag("canvas").transform.GetChild(1).GetChild(1).gameObject.SetActive(true);
    }
    static void setcamera(int number)
    {
        if (number == 1)
        {
            player1.transform.GetChild(11).gameObject.SetActive(false);
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>().rect = new Rect(0, 0.5f, 1, 0.5f);
            finishscene.transform.GetChild(5).GetComponent<CinemachineVirtualCamera>().LookAt = player1.transform;
        }
        else
        {
            player2.transform.GetChild(11).gameObject.SetActive(false);
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>().rect = new Rect(0, 0, 1, 0.5f);
            finishscene.transform.GetChild(1).GetComponent<CinemachineVirtualCamera>().LookAt = player2.transform;
        }
    }
    public void EndGame()
    {
        if (!flag && !flag2)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
    private void OnApplicationQuit()
    {
        Database.Save(); // incase the player turns off the game in this scene to save the data
    }
}
