using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent != null)
        {
            if (other.transform.parent.CompareTag("AIPlayer"))
            {
                Debug.Log("ai");
                RaceManager.aicheckpoint++;
                RaceManager.ChangePos();
            }
            else if (other.transform.parent.CompareTag("Player"))
            {
                Debug.Log("player");
                RaceManager.playercheckpoint++;
                RaceManager.ChangePos();
            }
        }
    }
}
