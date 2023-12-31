using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Checkpoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent != null)
        {
            if (SceneManager.GetActiveScene().name == "CasualScene")
            {
                if (other.transform.parent.CompareTag("Player"))
                {
                    if (other.transform.parent.GetComponent<player_number>().number == 1)
                    {
                        CasualRaceManager.player1checkpoint++;
                        CasualRaceManager.ChangePos();
                    }
                    else
                    {
                        CasualRaceManager.player2checkpoint++;
                        CasualRaceManager.ChangePos();
                    }
                }
                else
                {
                    if (other.transform.parent.name == "AiWaluigi(Clone)")
                    {
                        CasualRaceManager.ai1checkpoint++;
                        CasualRaceManager.ChangePos();
                    }
                    else
                    {
                        CasualRaceManager.ai2checkpoint++;
                        CasualRaceManager.ChangePos();
                    }
                }
            }
            else
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
}
