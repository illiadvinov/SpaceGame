using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : MonoBehaviour
{

    public int price = 150;
    public float capacity;
    public float currentCapacity; 
    public int health;
    private Converter converter;
    void Start()
    {
        converter = FindObjectOfType<Converter>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C) && FindObjectOfType<PlayerStats>().CLevel > 0)
        {
            Debug.Log("Converting energy");
            ConvertEnergy();
        }
    }

    public void Level(int level)
    {
        switch(level)
        {
            case(1): price = 300;
            capacity = 1000000;
            currentCapacity = 500000;
            health = 10;
            break;
            case(2): price = 450;
            capacity = 2000000;
            health = 5;
            break;
            case(3): capacity = 3000000;
            health = 5;
            break;
            default: break;
        }
    }

    public float BuyEnergy(float amountOfEnergy, float crypto)
    {
        float price = 0;
        if(amountOfEnergy >= 1 && amountOfEnergy < 100) 
        {
            price = amountOfEnergy * 0.5f;
            Debug.Log("Small");

        } 
        
        else if(amountOfEnergy >= 100 && amountOfEnergy < 500) 
        {
            price = amountOfEnergy * 0.4f;
            Debug.Log("Medium");
        } 
        else if(amountOfEnergy >= 500 && amountOfEnergy < 1500) 
        {
            price = amountOfEnergy * 0.3f;
            Debug.Log("Large");
        }
        else if(amountOfEnergy >= 1500) 
        {
            price = amountOfEnergy * 0.1f;
            Debug.Log("OPT");
        }

        if(price > 0) 
        {
            currentCapacity += amountOfEnergy;
            Debug.Log($"Price = {price}");
            return price;
        }
        else 
        {
            Debug.Log("No crypto");
            return 0;
        }

    }

    private void ConvertEnergy()
    {
        float aOE = 100;
        currentCapacity += converter.Convert(aOE);
        if(currentCapacity >= capacity) currentCapacity = capacity;
    }
}
