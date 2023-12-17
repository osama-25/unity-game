using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AIBubbleShieldMng : MonoBehaviour
{
    private void OnEnable()
    {
        activated();
    }
    public void activated()
    {
       transform.GetChild(0).gameObject.SetActive(true);
       Invoke("DisableBubble", 3);
    }
    void DisableBubble()
    {
        transform.GetChild(0).gameObject.SetActive(false);
        gameObject.SetActive(false);
    }
}
