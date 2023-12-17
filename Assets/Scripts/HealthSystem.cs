using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    public Image heart1, heart2, heart3;
    public Sprite heartfull, heartempty, halfheart;
    public float life = 3;
    private void Start()
    {
        heart1 = GameObject.FindGameObjectWithTag("canvas").transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Image>();
        heart2 = GameObject.FindGameObjectWithTag("canvas").transform.GetChild(0).GetChild(0).GetChild(1).GetComponent<Image>();
        heart3 = GameObject.FindGameObjectWithTag("canvas").transform.GetChild(0).GetChild(0).GetChild(2).GetComponent<Image>();
    }
    // Update is called once per frame
    void Update()
    {

    }
    public void checkhearts()
    {
        if (life == 0.5)
        {
            heart1.sprite = halfheart;
            heart2.sprite = heartempty;
            heart3.sprite = heartempty;
        }
        if (life == 1)
        {
            heart1.sprite = heartfull;
            heart2.sprite = heartempty;
            heart3.sprite = heartempty;
        }
        if (life == 1.5)
        {
            heart1.sprite = heartfull;
            heart2.sprite = halfheart;            
            heart3.sprite = heartempty;
        }
        if (life == 2)
        {
            heart1.sprite= heartfull;
            heart2.sprite= heartfull;
            heart3.sprite = heartempty;
        }
        if (life == 2.5)
        {
            heart1.sprite = heartfull;
            heart2.sprite = heartfull;
            heart3.sprite = halfheart;
        }
        if (life == 3)
        {
            heart1.sprite = heartfull;
            heart2.sprite = heartfull;
            heart3.sprite = heartfull;
        }
        if (life <= 0)
        {
            heart1.sprite = heartempty;
            gameObject.GetComponent<Car_Control>().enabled = false;
            Invoke("Enable", 3);
        }
    }
    void Enable()
    {
        gameObject.GetComponent<Car_Control>().enabled = true;
        life = 3;
        checkhearts();
    }
}
