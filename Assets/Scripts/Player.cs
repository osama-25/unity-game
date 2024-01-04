using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Gender { Male, Female}
public class Player 
{
    public string Name;
    public Gender Gender;
    public bool level1, level2, level3;

    public Player()
    {
        level1 = false;
        level2 = false;
        level3 = false;
    }
}
