using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidCollector : MonoBehaviour
{
    public int price = 75;
    public int health;
    public int collect; 
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
            case(1): price = 131;
            health = 10;
            collect = 20;
            break;
            case(2): price = 230;
            health = 2;
            collect = 30;
            break;
            case(3): collect = 40;
            health = 3;
            break;
            default: break;
        }
    }
}
