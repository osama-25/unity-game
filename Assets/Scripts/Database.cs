using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Database : MonoBehaviour
{
    void Start()
    {
        int count = PlayerPrefs.GetInt("players count"); // get the players count saved beforehand
        for(int i = 0; i < count; i++)
        {
            Player player = new Player();
            player.Name = PlayerPrefs.GetString("player " + i + " name");
            player.Gender = PlayerPrefs.GetInt("player " + i + " gender") == 1 ? Gender.Male : Gender.Female;
            player.level1 = PlayerPrefs.GetInt("player " + i + " level1") == 1;
            player.level2 = PlayerPrefs.GetInt("player " + i + " level2") == 1;
            player.level3 = PlayerPrefs.GetInt("player " + i + " level3") == 1;
            PlayerManager.players.Add(player); // add each player info retrieved into the players list
        }
    }
    private void OnApplicationQuit()
    {
        Save(); // make save public static so we could call it from anywhere in the game in applicationquit method
    }
    public static void Save()
    {
        PlayerPrefs.SetInt("players count", PlayerManager.players.Count); // save players count
        for (int i = 0; i < PlayerManager.players.Count; i++) // save each player info
        {
            PlayerPrefs.SetString("player " + i + " name", PlayerManager.players[i].Name);
            // cant save enum type so just save 1 for male and 0 for female
            PlayerPrefs.SetInt("player " + i + " gender", PlayerManager.players[i].Gender == Gender.Male ? 1 : 0); 
            PlayerPrefs.SetInt("player " + i + " level1", PlayerManager.players[i].level1 == true ? 1 : 0);
            PlayerPrefs.SetInt("player " + i + " level2", PlayerManager.players[i].level2 == true ? 1 : 0);
            PlayerPrefs.SetInt("player " + i + " level3", PlayerManager.players[i].level3 == true ? 1 : 0);
        }
    }
}
