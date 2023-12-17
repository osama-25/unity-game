using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Landminescript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            GetComponent<AudioSource>().Play();
            collision.gameObject.GetComponent<HealthSystem>().life -= 0.5f;
            collision.gameObject.GetComponent<HealthSystem>().checkhearts();
            Destroy(gameObject, 0.1f);
        }
        else if (collision.gameObject.CompareTag("AIPlayer"))
        {
            GetComponent<AudioSource>().Play();
            collision.gameObject.GetComponent<AIHealthSystem>().life -= 0.5f;
            collision.gameObject.GetComponent<AIHealthSystem>().checkhearts();
            Destroy(gameObject, 0.1f);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
