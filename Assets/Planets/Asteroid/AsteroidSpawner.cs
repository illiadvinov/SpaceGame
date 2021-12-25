using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField] GameObject Asteroid;
    [SerializeField] Vector3Int center;
    [SerializeField] Vector3Int size;
    Names names;

    public void Spawn()
    {
        Vector3Int position = center + new Vector3Int(Random.Range(-size.x / 2, size.x / 2), 0, Random.Range(-size.z / 2, size.z / 2));
        Instantiate(Asteroid, position, Quaternion.identity);
    }
}
