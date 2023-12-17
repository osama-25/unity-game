using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMysteryBox : MonoBehaviour
{
    public Transform point1;
    public Transform point2;
    public Transform point3;

    public GameObject mysterybox;

    private bool f1 = false, f2 = false, f3 = false;

    private void Start()
    {
        spawnmysterybox(point1);
        spawnmysterybox(point2);
        spawnmysterybox(point3);
    }
    private void Update()
    {
        if (!checkspawn(point1) && !f1)
        {
            f1 = true; 
            Invoke("spawn1", 4);
        }
        if (!checkspawn(point2) && !f2)
        {
            f2 = true;
            Invoke("spawn2", 4);
        }
        if (!checkspawn(point3) && !f3)
        {
            f3 = true;
            Invoke("spawn3", 4);
        }
    }
    void spawn1()
    {
        spawnmysterybox(point1);
        f1 = false;
    }
    void spawn2()
    {
        spawnmysterybox(point2);
        f2 = false;
    }
    void spawn3()
    {
        spawnmysterybox(point3);
        f3 = false;
    }
    bool checkspawn(Transform point)
    {
        for (int i = 0; i < 3; i++)
        {
            if (point.GetChild(i).childCount > 0)
            {
                return true;
            }
        }
        return false;
    }
    void spawnmysterybox(Transform point)
    {
        for (int i = 0; i < 3; i++)
        {
            GameObject clone = Instantiate(mysterybox, point.GetChild(i));
            clone.transform.position = point.GetChild(i).position;
        }
    }
}
