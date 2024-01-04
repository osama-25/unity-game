using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    private GameObject Canvas;
    private void Start()
    {
        Canvas = GameObject.FindGameObjectWithTag("canvas");
        if (PlayerManager.ChosenPlayer.level1 == false)
        {
            Canvas.transform.GetChild(1).GetChild(0).GetChild(1).GetChild(1).gameObject.SetActive(true);
            Canvas.transform.GetChild(1).GetChild(0).GetChild(2).GetChild(1).gameObject.SetActive(true);
        }
        else if(PlayerManager.ChosenPlayer.level2 == false)
        {
            Canvas.transform.GetChild(1).GetChild(0).GetChild(2).GetChild(1).gameObject.SetActive(true);
        }
    }
    public void ChooseLevel1()
    {
        CarSelection.mode = 0;
        CarSelection.level = 1;
        SceneManager.LoadScene("CarSelectionScene");
    }
    public void ChooseLevel2() 
    {
        if (!Canvas.transform.GetChild(1).GetChild(0).GetChild(1).GetChild(1).gameObject.activeSelf)
        {
            CarSelection.mode = 0;
            CarSelection.level = 2;
            SceneManager.LoadScene("CarSelectionScene");
        }
    }
    public void ChooseLevel3() 
    {
        if (!Canvas.transform.GetChild(1).GetChild(0).GetChild(2).GetChild(1).gameObject.activeSelf)
        {
            CarSelection.mode = 0;
            CarSelection.level = 3;
            SceneManager.LoadScene("CarSelectionScene");
        }
    }
    public void ChooseCasual()
    {
        CarSelection.mode = 1;
        SceneManager.LoadScene("CarSelectionScene");
    }
    public void Home()
    {
        Canvas.transform.GetChild(0).gameObject.SetActive(true);
        Canvas.transform.GetChild(1).gameObject.SetActive(false);
    }
    public void ChooseLevels()
    {
        Canvas.transform.GetChild(1).gameObject.SetActive(true);
        Canvas.transform.GetChild(0).gameObject.SetActive(false);
    }
    public void ChangePlayer()
    {
        SceneManager.LoadScene("ProfileScene");
    }
    private void OnApplicationQuit()
    {
        Database.Save(); // incase the player turns off the game in this scene to save the data
    }
}
