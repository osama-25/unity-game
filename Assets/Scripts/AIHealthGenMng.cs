using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AIHealthGenMng : MonoBehaviour
{
    public ParticleSystem healthgen;

    private void OnEnable()
    {
        activated();
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
            if (transform.parent.parent.GetComponent<AIHealthSystem>().life >= 3)
            {
                break;
            }
            transform.parent.parent.GetComponent<AIHealthSystem>().life += 0.5f;
        }
    }
    void StopGen()
    {
        healthgen.gameObject.SetActive(false);
        gameObject.SetActive(false);
    }
}
