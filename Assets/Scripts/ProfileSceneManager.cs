using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ProfileSceneManager : MonoBehaviour
{
    private GameObject Canvas;

    public InputField playername;
    public Toggle male;
    public Toggle female;

    public Dropdown currentplayers;

    public Text warning;
    public Button add;
    private void Start()
    {
        Canvas = GameObject.FindGameObjectWithTag("canvas");
    }
    public void ChooseNew()
    {
        Canvas.transform.GetChild(0).gameObject.SetActive(false);
        Canvas.transform.GetChild(2).gameObject.SetActive(true);
    }
    public void ChooseCurrent()
    {
        Canvas.transform.GetChild(0).gameObject.SetActive(false);
        Canvas.transform.GetChild(1).gameObject.SetActive(true);

        currentplayers.ClearOptions();
        List<string> playersnames = new List<string>();
        foreach (Player p in PlayerManager.players)
        {
            playersnames.Add(p.Name);
        }
        currentplayers.AddOptions(playersnames);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void GoBackFromCurrent()
    {
        Canvas.transform.GetChild(0).gameObject.SetActive(true);
        Canvas.transform.GetChild(1).gameObject.SetActive(false);
    }
    public void GoBackFromNew()
    {
        Canvas.transform.GetChild(0).gameObject.SetActive(true);
        Canvas.transform.GetChild(2).gameObject.SetActive(false);
    }
    public void Add()
    {
        // get the data entered by the user to create a new player object
        // add the player object to players list and assign it to chosenplayer

        Player player = new Player();
        player.Name = playername.text;
        if (male.isOn)
        {
            player.Gender = Gender.Male;
        }
        else if (female.isOn)
        {
            player.Gender = Gender.Female;
        }
        PlayerManager.players.Add(player);
        PlayerManager.ChosenPlayer = player;

        SceneManager.LoadScene("MainMenu");
    }
    public void Play()
    {
        // get the chosen player name and search for the object in the players list to assign it to chosenplayer
        string chosen = currentplayers.options[currentplayers.value].text;
        foreach (Player p in PlayerManager.players)
        {
            if (p.Name == chosen)
            {
                PlayerManager.ChosenPlayer = p;
                break;
            }
        }

        SceneManager.LoadScene("MainMenu");
    }
    public void CheckName()
    {
        // if name is already chosen display warning message
        foreach (Player p in PlayerManager.players)
        {
            if (playername.text == p.Name)
            {
                warning.gameObject.SetActive(true);
                add.gameObject.SetActive(false);
            }
            else
            {
                warning.gameObject.SetActive(false);
                add.gameObject.SetActive(true);
            }
        }
    }
    private void OnApplicationQuit()
    {
        Database.Save(); // incase the player turns off the game in this scene to save the data
    }
}
