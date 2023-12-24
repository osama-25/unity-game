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
                RaceManager.aicheckpoint++;
                RaceManager.ChangePos();
            }
            else if (other.transform.parent.CompareTag("Player"))
            {
                RaceManager.playercheckpoint++;
                RaceManager.ChangePos();
            }
        }
    }
}
