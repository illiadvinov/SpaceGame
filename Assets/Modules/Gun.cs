using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public int price = 150;
    public int health;
    public int damage;
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
            damage = 50;
            health = -5;
            break;
            case(2): price = 216;
            damage = 60;
            health = 2;
            break;
            case(3): damage = 75;
            health = 3;
            break;
            default: break;
        }
    }

    public void Shoot()
    {
        
    }
}
