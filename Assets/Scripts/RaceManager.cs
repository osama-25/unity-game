using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RaceManager : MonoBehaviour
{
    public static int playercheckpoint = 0, aicheckpoint = 0;
    public static Text postext;

    public static bool flag = true;

    public static Text resulttext, first, second;
    public static GameObject finishscene;

    private static GameObject player, aiplayer;
    private void Start()
    {
        aiplayer = GameObject.FindGameObjectWithTag("AIPlayer");
        player = GameObject.FindGameObjectWithTag("Player");
        finishscene = GameObject.FindGameObjectWithTag("cameras").transform.GetChild(1).gameObject;
        postext = GameObject.FindGameObjectWithTag("canvas").transform.GetChild(0).GetChild(4).GetComponent<Text>();
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
                first.text = "1- " + aiplayer.name;
                second.text = "2- " + player.name + " (You)";
            }
            else if (winner == "player")
            {
                setcamera("you");
                finishscene.transform.GetChild(2).gameObject.SetActive(true);
                resulttext.text = "You Won";
                first.text = "1- " + player.name + " (You)";
                second.text = "2- " + aiplayer.name;
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
    public void GameEnded()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void Win()
    {
        if (SceneManager.GetActiveScene().name == "NormalScene")
        {
            PlayerManager.ChosenPlayer.level1 = true;
        }
        else if (SceneManager.GetActiveScene().name == "SnowyScene")
        {
            PlayerManager.ChosenPlayer.level2 = true;
        }
        else if (SceneManager.GetActiveScene().name == "RainyScene")
        {
            PlayerManager.ChosenPlayer.level3 = true;
        }
    }
    private void OnApplicationQuit()
    {
        Database.Save(); // incase the player turns off the game in this scene to save the data
    }
}
