using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engine : MonoBehaviour
{
    public int price = 200;
    public int health ;
    public int battle;
    private int movement;
    [SerializeField] Transform parent;
    private Battery battery;
    private Generator generator;
    public int level { get; set;}
    
    
    // Start is called before the first frame update
    private void Start()
    {
        battery = FindObjectOfType<Battery>();
        generator = FindObjectOfType<Generator>();
    }

    // Update is called once per frame
    private void Update()
    {
    
        
    }

    public void Level(int level)
    {
        switch(level)
        {
            case(1): price = 100;
            health = -10;
            battle = 10;
            movement = 5;
            this.level = level; 
            break;
            case(2): price = 150;
            movement = 48;
            battle = 8;
            health = 2;
            this.level = level;
            break;
            case(3): movement = 45;
            battle = 6;
            health = 3;
            this.level = level;
            break;
            default: break;
        }
    }

    public void Move(Vector3 position)
    {
        float energyToMove = 0; 
        if(Mathf.Abs(position.x) > Mathf.Abs(position.z)) 
        {
            int way = Mathf.Abs(Mathf.FloorToInt(position.x/5) - Mathf.FloorToInt(parent.position.x/5));
            energyToMove = (movement * 10) * way; 
            if(FindObjectOfType<PlayerStats>().GenLevel > 0)
            {
                energyToMove -= generator.Generate(way);
            }
            //Debug.Log($"X is bigger and way is {way}");
        }
        else 
        {
            int way = Mathf.Abs(Mathf.FloorToInt(position.z/5) - Mathf.FloorToInt(parent.position.z/5));
            energyToMove = (movement * 10) * way; 
            //Debug.Log($"Z is bigger and way is {way}");
        }

        //Debug.Log($"{energyToMove}");
        
        if(battery.currentCapacity > energyToMove)
        {
            battery.currentCapacity -= energyToMove;
            parent.position = Vector3.Lerp(parent.position, position, Time.deltaTime * 100) ;
            
        }
       // else Debug.Log("No power");
        
    }
}
