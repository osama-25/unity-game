using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Boost : MonoBehaviour
{
    private float boost = 1, maxboost = 1;
    private Car_Control car;
    public bool isboosting;

    private float boostForce = 7f;
    private float decelerationFactor = 0.5f;

    private Rigidbody rb;

    private Slider boostbar;

    public GameObject smoke;
    public GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        car = GetComponent<Car_Control>();
        if (SceneManager.GetActiveScene().name == "CasualScene")
        {
            if (gameObject.GetComponent<player_number>().number == 1)
            {
                boostbar = GameObject.FindGameObjectWithTag("canvas").transform.GetChild(0).GetChild(0).GetChild(1).GetComponent<Slider>();
            }
            else
            {
                boostbar = GameObject.FindGameObjectWithTag("canvas").transform.GetChild(1).GetChild(0).GetChild(1).GetComponent<Slider>();
            }
        }
        else
        {
            boostbar = GameObject.FindGameObjectWithTag("canvas").transform.GetChild(0).GetChild(1).GetComponent<Slider>();
        }
        boostbar.maxValue = maxboost;
        boostbar.value = boost;
    }
    public void SetBoost(bool isboosting)
    {
        this.isboosting = isboosting;
        //car.maxTorque = isboosting ? boostspeed : normalspeed;

        if (isboosting && boost > 0)
        {
            smoke.SetActive(false);
            explosion.SetActive(true);
            
            var force = transform.forward * 10;
            rb.AddForce(force, ForceMode.Acceleration);

            boost -= Time.deltaTime;
            if (boost < 0)
            {
                boost = 0;
                SetBoost(false);
            }
        }
        else if (boost < maxboost)
        {
            smoke.SetActive(true);
            explosion.SetActive(false);
            
            // Decelerate the car gradually
            Vector3 currentVelocity = rb.velocity;
            Vector3 decelerationForce = -currentVelocity.normalized * boostForce * decelerationFactor;
            rb.AddForce(decelerationForce, ForceMode.Acceleration);
            StartCoroutine("generateboost");
        }
        boostbar.value = boost;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (SceneManager.GetActiveScene().name == "CasualScene")
        {
            if (gameObject.GetComponent<player_number>().number == 1)
            {
                if (Input.GetKey(KeyCode.Space))
                {
                    SetBoost(true);
                }
                else
                {
                    SetBoost(false);
                }
            }
            else
            {
                if (Input.GetKey(KeyCode.RightControl))
                {
                    SetBoost(true);
                }
                else
                {
                    SetBoost(false);
                }
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.Space))
            {
                SetBoost(true);
            }
            else 
            {
                SetBoost(false);
            }
        }
    }
    IEnumerator generateboost()
    {
        yield return new WaitForSeconds(2f);
        boost += Time.deltaTime;
        boost = Mathf.Clamp(boost, 0f, maxboost);
    }
}
