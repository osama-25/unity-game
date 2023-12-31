using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LaunchMissiles : MonoBehaviour
{
    public GameObject missile;

    public Transform m1, m2, m3;

    public GameObject missilepic;

    public Image img;
    public Sprite missileimg;
    // Start is called before the first frame update
    void OnEnable()
    {
        if (SceneManager.GetActiveScene().name == "CasualScene")
        {
            if (transform.parent.parent.GetComponent<player_number>().number == 1)
            {
                img = GameObject.FindGameObjectWithTag("canvas").transform.GetChild(0).GetChild(0).GetChild(2).GetComponent<Image>();
            }
            else
            {
                img = GameObject.FindGameObjectWithTag("canvas").transform.GetChild(1).GetChild(0).GetChild(2).GetComponent<Image>();
            }
        }
        else
        {
            img = GameObject.FindGameObjectWithTag("canvas").transform.GetChild(0).GetChild(2).GetComponent<Image>();
        }
        img.gameObject.SetActive(true);
        img.sprite = missileimg;
        missilepic.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "CasualScene")
        {
            if (transform.parent.parent.GetComponent<player_number>().number == 1)
            {
                if (Input.GetKeyDown(KeyCode.LeftShift))
                {
                    activated();
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.RightShift))
                {
                    activated();
                }
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                activated();
            }
        }
    }
    public void activated()
    {
        DestroyPic();
        Launch();
        gameObject.SetActive(false);
        img.gameObject.SetActive(false);
    }
    void DestroyPic()
    {
        missilepic.SetActive(false);
    }
    void Launch()
    {
        Instantiate(missile, m1.position, m1.rotation);
        Instantiate(missile, m2.position, m2.rotation);
        Instantiate(missile, m3.position, m3.rotation);
    }
}
