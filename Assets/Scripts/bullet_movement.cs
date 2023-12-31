using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_movement : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("wall"))
        {
            Destroy(gameObject);
        }
        if (other.transform.parent != null)
        {
            if (other.transform.parent.CompareTag("Player"))
            {
                other.transform.parent.gameObject.GetComponent<HealthSystem>().life -= 0.5f;
                other.transform.parent.gameObject.GetComponent<HealthSystem>().checkhearts();
                Destroy(gameObject);
            }
            else if (other.transform.parent.CompareTag("AIPlayer"))
            {
                other.transform.parent.gameObject.GetComponent<AIHealthSystem>().life -= 0.5f;
                other.transform.parent.gameObject.GetComponent<AIHealthSystem>().checkhearts();
                Destroy(gameObject);
            }
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
    }
}
