using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProfileSceneManager : MonoBehaviour
{
    private GameObject Canvas;
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

    }
    public void Play()
    {
        
    }
}
