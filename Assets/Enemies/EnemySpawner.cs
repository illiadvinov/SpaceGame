using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemy;
 

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Spawn(Vector3Int center) 
    {
        
        center.x += 1;
        center.z += 1;
        Vector3Int size = new Vector3Int(10, 0, 10);
        Vector3Int position = center  + new Vector3Int(Random.Range(-size.x , size.x ), 0, Random.Range(-size.z , size.z));
        
        Instantiate(enemy, position, Quaternion.identity);
    
    }
    
}
