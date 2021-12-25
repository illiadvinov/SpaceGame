using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repairment : MonoBehaviour
{
    public int price = 350;
    public int health = 10;
    private int efficiency = 20;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     public void Level(int level)
    {
        switch(level)
        {
            case(1): price = 438;
            break;
            case(2): price = 547;
            health = 5;
            efficiency = 25;
            break;
            case(3): efficiency = 30;
            break;
            default: break;
        }
    }

    public int Repair(int health)
    {
        health += efficiency;
        FindObjectOfType<Battery>().currentCapacity -= 10;
        return health;
    }
}
