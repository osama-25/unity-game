using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AIDropLandMine : MonoBehaviour
{
    private int counter = 0;

    public GameObject landmine;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            activated();
        }
    }
    private void OnEnable()
    {
        StartCoroutine(aidrop());
    }
    IEnumerator aidrop()
    {
        activated();
        yield return new WaitForSeconds(1f);
        activated();
    }
    public void activated()
    {
        counter++;
        Drop();
        if (counter >= 2)
        {
             gameObject.SetActive(false);
             counter = 0;
        }
    }
    void Drop()
    {
        Instantiate(landmine, transform.position, transform.rotation);
    }
}
