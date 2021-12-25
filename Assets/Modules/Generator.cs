using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public int price = 250;
    public int health = 5;
    private int efficiency = 2; // 100km
    // Start is called before the first frame update
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
            case(1): price = 388;
            break;
            case(2): price = 601;
            health = 3;
            efficiency = 4;
            break;
            case(3): health = 2;
            efficiency = 6;
            break;
            default: break;
        }
    }

    public float Generate(float way)
    {
        float energy = way * (efficiency * 10);
        return energy;
    }
}
