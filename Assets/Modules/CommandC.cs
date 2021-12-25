using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandC : MonoBehaviour
{
   // public int level;
    public int price = 100;
    public int health = 10;
    public int bodyLimit = 0;
    
     public void Level(int level)
    {
        switch(level)
        {
            case(1): price = 300;
            bodyLimit = 4;
            break;
            case(2): price = 900;
            health = 10;
            bodyLimit = 8;
            break;
            case(3):
            health = 10;
            bodyLimit = 12;
            break;
            default: Debug.Log("Max Level");
            break;
        }
    }
}
