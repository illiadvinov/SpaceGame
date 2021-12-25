using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private float amountOfRescourses;
    private OreStorage storage;
    private AsteroidCollector asteroid;
    private Battery battery;
    private int counter = 0;

   
    void Start()
    {
        storage = FindObjectOfType<OreStorage>();
        asteroid = FindObjectOfType<AsteroidCollector>();
        battery = FindObjectOfType<Battery>();
    }

    private void OnEnable() {

        amountOfRescourses = Random.Range(100f, 1000f);
    }

    private void OnTriggerEnter(Collider other) 
    {
        
        if(other.tag == "Player")
        {
            if(storage.ore >= storage.capacityOre) 
            {
                Debug.Log("You have maximum ore");
                return;
            }

            
            Debug.Log(amountOfRescourses);

            counter++;
            storage.ore += asteroid.collect;
            battery.currentCapacity -= 1;
            amountOfRescourses -= asteroid.collect;
                
             if(storage.ore >= storage.capacityOre)
            {
                storage.ore = storage.capacityOre;
            }
            Debug.Log($"You took {storage.ore} ore");
            if(amountOfRescourses <= 0)
            {
                Debug.Log("All recourses were taken");
                Destroy(gameObject);
            }

         

           
            
        }
    }
}
