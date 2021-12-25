using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resources : MonoBehaviour
{
    OreStorage os;
    EnemySpawner es;


    // Start is called before the first frame update
    void Start()
    {
        os = FindObjectOfType<OreStorage>();
        es = FindObjectOfType<EnemySpawner>();
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "Player")
        {
            os.ore = os.capacityOre;
            Debug.Log("Recourses were taken");

            if(Random.value > 0.6f)
           {
                es.Spawn(Vector3Int.RoundToInt(transform.position));
                FindObjectOfType<Fight>().StartFight();
           }
            
        }
    }

    
}
