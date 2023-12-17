using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthGenMng : MonoBehaviour
{
    public Image img;
    public Sprite healthgenimg;

    public ParticleSystem healthgen;
    // Start is called before the first frame update
    void OnEnable()
    {
        img = GameObject.FindGameObjectWithTag("canvas").transform.GetChild(0).GetChild(2).GetComponent<Image>();
        img.gameObject.SetActive(true);
        img.sprite = healthgenimg;
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
        generatehearts();
        healthgen.gameObject.SetActive(true);
        Invoke("StopGen", 3);
    }
    void generatehearts()
    {
        for (int i = 0; i < 4; i++)
        {
            if (transform.parent.parent.GetComponent<HealthSystem>().life >= 3)
            {
                break;
            }
            transform.parent.parent.GetComponent<HealthSystem>().life += 0.5f;
            transform.parent.parent.GetComponent<HealthSystem>().checkhearts();
        }
    }
    void StopGen()
    {
        healthgen.gameObject.SetActive(false);
        img.gameObject.SetActive(false);
        gameObject.SetActive(false);
    }
}
