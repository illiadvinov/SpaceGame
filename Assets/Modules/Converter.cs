using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Converter : MonoBehaviour
{
    public int price = 200;
    public int health = -5;
    private int efficiency = 5; //1МВт == .1ГВт From 5 ores
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
            case(1): price = 270;
            break;
            case(2): price = 365;
            health = 2;
            efficiency = 4;
            break;
            case(3): health = 3;
            efficiency = 3;
            break;
            default: break;
        }
    }

    public float Convert(float energy)
    {
        float amount = energy * efficiency;
        if(amount <= FindObjectOfType<OreStorage>().ore)
        {
            FindObjectOfType<OreStorage>().ore -= amount;
            return energy;
        }
        else return 0;

    }
}
