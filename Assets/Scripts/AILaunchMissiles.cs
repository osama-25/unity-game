using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AILaunchMissiles : MonoBehaviour
{
    public GameObject missile;

    public Transform m1, m2, m3;

    public GameObject missilepic;

    private void OnEnable()
    {
        missilepic.SetActive(true);
        activated();
    }
    public void activated()
    {
        DestroyPic();
        Launch();
        gameObject.SetActive(false);
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
