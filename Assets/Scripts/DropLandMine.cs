using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropLandMine : MonoBehaviour
{
    private int counter = 0;

    public GameObject landmine;

    public Image img;
    public Sprite Landmineimg;
    // Start is called before the first frame update
    void OnEnable()
    {
        img = GameObject.FindGameObjectWithTag("canvas").transform.GetChild(0).GetChild(2).GetComponent<Image>();
        img.gameObject.SetActive(true);
        img.sprite = Landmineimg;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            activated();
        }
    }
    public void activated()
    {
       counter++;
       Drop();
       if (counter >= 2)
       {
            gameObject.SetActive(false);
            img.gameObject.SetActive(false);
            counter = 0;
       }
    }
    void Drop()
    {
        Instantiate(landmine, transform.position, transform.rotation);
    }
}
