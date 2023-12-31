using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BubbleShieldMng : MonoBehaviour
{
    public Image img;
    public Sprite shieldimg;
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
        img.sprite = shieldimg;
    }
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
       transform.GetChild(0).gameObject.SetActive(true);
       Invoke("DisableBubble", 3);
    }
    void DisableBubble()
    {
        transform.GetChild(0).gameObject.SetActive(false);
        img.gameObject.SetActive(false);
        gameObject.SetActive(false);
    }
}
