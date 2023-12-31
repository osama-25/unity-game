using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class pickupgun : MonoBehaviour
{
    private bool flag = true;
    public AudioSource pickupsound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent != null && other.tag != "bubble")
        {
            pickupsound.Play();
            for (int i = 0; i < 4; i++)
            {
                if (other.transform.parent.GetChild(8).GetChild(i).gameObject.activeSelf == true)
                {
                    flag = false;
                    break;
                }
            }
            if (flag)
            {
                System.Random r = new System.Random();
                int rnd = r.Next(0, 4);
                other.transform.parent.GetChild(8).GetChild(rnd).gameObject.SetActive(true);
            }
            Destroy(gameObject, 0.1f);
        }
    }
}
