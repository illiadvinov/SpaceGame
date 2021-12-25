using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Base : MonoBehaviour
{

    PlayerStats p;
    int c;
    // Start is called before the first frame update
    private void Awake()
    {
        p = FindObjectOfType<PlayerStats>();
    }


    private void Update()
    {
        Input();

    }

    
    private void OnTriggerEnter(Collider other) 
    {
        Debug.Log("Press E to go to Hub, Press N to sell Ore, Press B to buy an Energy");
    }

    private void OnTriggerStay(Collider other) 
   {
       if(other.tag == "Player")
        {
            if(p.levels == 30)
            {
                Debug.Log("You have all max modules\n Ending game");
                Application.Quit();
            }
            else if(p.crypto >= 5000)
            {
                Debug.Log("You have earned 5000 crypto. It's The End");
                Application.Quit();
            }

            switch(c)
            {
                case 1: p.UpgradeCommandC();
                c = 0;
                break;
                case 2: p.UpgradeBody();
                c = 0;
                break;
                case 3: p.UpgradeEngine();
                c = 0;
                break;
                case 4: p.UpgradeBattery();
                c = 0;
                break;
                case 5: p.UpgradeStorage();
                c = 0;
                break;
                case 6: p.UpgradeGun();
                c = 0;
                break;
                case 7: p.UpgradeAsteroidCollector();
                c = 0;
                break;
                case 8: p.UpgradeConverter();
                c = 0;
                break;
                case 9: p.UpgradeGenerator();
                c = 0;
                break;
                case 10: p.UpgradeRepairment();
                c = 0;
                break;
                case 11: Debug.Log("Selling all ore");
                p.SellOre();
                c = 0;
                break;
                case 12:  Debug.Log("Type how much energy you want");
                float aoe = 50;
                p.BuyEnergy(aoe);
                c = 0;
                break;
                default: Debug.Log("Wrong key");
                break;
            }

            // if (Input.GetKeyDown(KeyCode.S))
            // {
            //     Debug.Log("Selling all ore");
            //     ps.SellOre();
            // }

            // if (Input.GetKeyDown(KeyCode.B))
            // {
            //     Debug.Log("Type how much energy you want");
            //     float aoe = 50;
                
            //     ps.BuyEnergy(aoe);
            // }
        }

    }

    private void Input()
    {
        if (UnityEngine.Input.GetKeyDown(KeyCode.Alpha1))
        {
            c = 1;
        }
        if (UnityEngine.Input.GetKeyDown(KeyCode.Alpha2))
        {
            c = 2;
        }
        if (UnityEngine.Input.GetKeyDown(KeyCode.Alpha3))
        {
            c = 3;
        }
        if (UnityEngine.Input.GetKeyDown(KeyCode.Alpha4))
        {

            c = 4;
        }
        if (UnityEngine.Input.GetKeyDown(KeyCode.Alpha5))
        {
            c = 5;
        }
        if (UnityEngine.Input.GetKeyDown(KeyCode.Alpha6))
        {
            c = 6;
        }
        if (UnityEngine.Input.GetKeyDown(KeyCode.Alpha7))
        {
            c = 7;
        }
        if (UnityEngine.Input.GetKeyDown(KeyCode.Alpha8))
        {
            c = 8;
        }
        if (UnityEngine.Input.GetKeyDown(KeyCode.Alpha9))
        {
            c = 9;
        }
        if (UnityEngine.Input.GetKeyDown(KeyCode.Alpha0))
        {
            c = 10;
        }
        if (UnityEngine.Input.GetKeyDown(KeyCode.N))
        {
            c = 11;
        }

        if (UnityEngine.Input.GetKeyDown(KeyCode.B))
        {
            c = 12;
        }
    }
}


   
