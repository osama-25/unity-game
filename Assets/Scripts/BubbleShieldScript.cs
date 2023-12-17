using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleShieldScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("weapon"))
        {
            Destroy(other);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
