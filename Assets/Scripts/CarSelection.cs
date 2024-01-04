using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CarSelection : MonoBehaviour
{
    public static int mode;
    public static int level;

    public GameObject[] cars;
    public Button next;
    public Button prev;
    int index; // it holds which car is selected from the array

    public Button nextcar;
    public Button play;
    public Text carnumber;

    public GameObject[] carsprefabs;
    public GameObject[] pvpcars;

    public Image Lock;

    void Start()
    {
        if (mode == 1)
        {
            nextcar.gameObject.SetActive(true);
            play.gameObject.SetActive(false);
            carnumber.gameObject.SetActive(true);
        }

        index = PlayerPrefs.GetInt("carIndex");

        for (int i = 0; i < cars.Length; i++)
        {
            cars[i].SetActive(false);
            cars[index].SetActive(true);
        }
        CheckLock();
    }

    void Update()
    {
        if (index >= 4)
        {
            next.interactable = false;
        }
        else
        {
            next.interactable = true;
        }

        if (index <= 0)
        {
            prev.interactable = false;
        }
        else
        {
            prev.interactable = true;
        }
    }

    public void Next()
    {
        Lock.gameObject.SetActive(false);

        index++;

        for (int i = 0; i < cars.Length; i++)
        {
            cars[i].SetActive(false);
            cars[index].SetActive(true);
        }

        PlayerPrefs.SetInt("carIndex", index);
        PlayerPrefs.Save();

        CheckLock();
    }

    public void Prev()
    {
        Lock.gameObject.SetActive(false);

        index--;

        for (int i = 0; i < cars.Length; i++)
        {
            cars[i].SetActive(false);
            cars[index].SetActive(true);
        }

        PlayerPrefs.SetInt("carIndex", index);
        PlayerPrefs.Save();

        CheckLock();
    }

    public void Race()
    {
        if (!Lock.gameObject.activeSelf)
        {
            if (mode == 1)
            {
                PlaceCar.Car2 = pvpcars[index];
                SceneManager.LoadScene("CasualScene");
            }
            else
            {
                PlaceCar.Car = carsprefabs[index];
                if (level == 1)
                {
                    SceneManager.LoadScene("NormalScene");
                }
                else if (level == 2)
                {
                    SceneManager.LoadScene("SnowyScene");
                }
                else if (level == 3)
                {
                    SceneManager.LoadScene("RainyScene");
                }
            }
        }
    }
    public void NextCar()
    {
        if (!Lock.gameObject.activeSelf)
        {
            PlaceCar.Car = pvpcars[index];
            nextcar.gameObject.SetActive(false);
            play.gameObject.SetActive(true);
            carnumber.text = "Car 2";
        }
    }
    public void Back()
    {
        SceneManager.LoadScene("MainMenu");
    }
    private void CheckLock()
    {
        if (index == 1)
        {
            if (PlayerManager.ChosenPlayer.level3 == false)
            {
                Lock.gameObject.SetActive(true);
            }
        }
        if (index == 2)
        {
            if (PlayerManager.ChosenPlayer.level2 == false)
            {
                Lock.gameObject.SetActive(true);
            }
        }
        if (index == 4)
        {
            if (PlayerManager.ChosenPlayer.level1 == false)
            {
                Lock.gameObject.SetActive(true);
            }
        }
    }
    private void OnApplicationQuit()
    {
        Database.Save(); // incase the player turns off the game in this scene to save the data
    }
}
