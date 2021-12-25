using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OreStorage : MonoBehaviour
{
    public int price = 50;
    public int health = 10;
    public float capacityOre = 2000;
    public float ore = 0;
    public float Ore { get; set; }
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
            case(1): price = 65;
            break;
            case(2): price = 85;
            capacityOre = 3000;
            health = 5;
            break;
            case(3): capacityOre = 4000;
            health = 5;
            break;
            default: break;
        }
    }

    public float SellOre(float crypto)
    {
        Debug.Log($"You have taken {ore} ore");
        if(ore >= 1 && ore < 100) crypto += ore * 0.12f;
        else if(ore >= 100 && ore < 500) crypto += ore * 0.1f;
        else if(ore >= 500 && ore < 1500) crypto += ore * 0.08f;
        else if(ore >= 1500) crypto += ore * 0.06f;
        else crypto = 0;
        ore = 0;

        
        return crypto;
    
    }

}
