using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AIHealthSystem : MonoBehaviour
{
    public float life = 4;
    public void checkhearts()
    {
        if (life <= 0)
        {
            gameObject.GetComponent<AIcontrol>().enabled = false;
            Invoke("Enable", 3);
        }
    }
    void Enable()
    {
        gameObject.GetComponent<AIcontrol>().enabled = true;
        life = 4;
        checkhearts();
    }
}
