using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public int health = 10;
    public int damage = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable() {
        CreateStats();
    }

    public void CreateStats()
    {
        int numOfModules = Random.Range(4, 10);
        Debug.Log(numOfModules);
        BodyStats();
        GunStats();

        switch(numOfModules)
        {
            default: 
            case 4: EngineStats();
            break;
            case 5: EngineStats();
            BatteryStats();
            break;
            case 6: EngineStats();
            BatteryStats();
            StorageStats();
            break;
            case 7: EngineStats();
            BatteryStats();
            StorageStats();
            AsteroidCollectorStats();
            break;
            case 8: EngineStats();
            BatteryStats();
            StorageStats();
            AsteroidCollectorStats();
            ConverterStats();
            break;
            case 9: EngineStats();
            BatteryStats();
            StorageStats();
            AsteroidCollectorStats();
            ConverterStats();
            GeneratorStats();
            break;
        }

    }

    private void BodyStats()
    {
        int level = Random.Range(1, 4);
        switch(level)
        {
            default: 
            case 1: health += 100;
            break;
            case 2: health += 200;
            break;
            case 3: health += 300;
            break;
        }
         Debug.Log("Body level " + level);
    }
    private void GunStats()
    {
        int level = Random.Range(1, 3);
        switch(level)
        {
            default: 
            case 1: health -= 10;
            damage += 100; 
            break;
            case 2: health -= 6;
            damage += 120;
            break;
            case 3: health += 2;
            damage += 150;
            break;
        }
        Debug.Log("Gun level " + level);
    }

    private void EngineStats()
    {
        int level = Random.Range(1, 4);
        switch(level)
        {
            default: 
            case 1: health -= 10;
            break;
            case 2: health -= 8;
            break;
            case 3: health -= -5;
            break;
        }
        Debug.Log("Engine level " + level);
    }
    private void BatteryStats()
    {
        int level = Random.Range(1, 4);
        switch(level)
        {
            default: 
            case 1: health += 10;
            break;
            case 2: health += 15;
            break;
            case 3: health += 20;
            break;
        }
         Debug.Log("Battery level " + level);
    }
    private void StorageStats()
    {
        int level = Random.Range(1, 4);
        switch(level)
        {
            default: 
            case 1: health += 10;
            break;
            case 2: health += 15;
            break;
            case 3: health += 20;
            break;
        }
        Debug.Log("Storage level " + level);
    }
    private void AsteroidCollectorStats()
    {
        int level = Random.Range(1, 4);
        switch(level)
        {
            default: 
            case 1: health += 10;
            break;
            case 2: health += 12;
            break;
            case 3: health += 15;
            break;
        }
        Debug.Log("Asteroid Collector level " + level);
    }
     private void ConverterStats()
    {
        int level = Random.Range(1, 4);
        switch(level)
        {
            default: 
            case 1: health -= 5;
            break;
            case 2: health -= 3;
            break;
            case 3: health += 0;
            break;
        }
        Debug.Log("Converter level " + level);
    }
    private void GeneratorStats()
    {
        int level = Random.Range(1, 4);
        switch(level)
        {
            default: 
            case 1: health += 5;
            break;
            case 2: health += 8;
            break;
            case 3: health += 10;
            break;
        }
        Debug.Log("Generator level " + level);
    }
}


