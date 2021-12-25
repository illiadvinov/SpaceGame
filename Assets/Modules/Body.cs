using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour
{
   // public int level = 1;
    public int price = 100;
    public int health;

    public void Level(int level)
    {
        switch(level)
        {
            case(1): price = 250;
            health = 100;
            break;
            case(2): price = 350;
            health = 100;
            break;
            case(3): health = 100;
            break;
            default: break;
        }
    }
}
