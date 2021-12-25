using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float crypto = 2500;
    public int health = 0;
    public int damage = 0;
    private int CCLevel = 0;
    private int BLevel = 0;
    private int ELevel = 0;
    private int BatLevel = 0;
    private int SLevel = 0;
    private int GLevel = 0;
    private int ACLevel = 0;
    public int CLevel = 0;
    public int GenLevel = 0;
    private int RLevel = 0;
    public int levels = 0;
    public int mainModules = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R) && RLevel > 0)
        {
            Debug.Log("Ship is repairing");
            StartCoroutine(Regen());
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Are you want to exit? Y- to exit");
            if(Input.GetKeyDown(KeyCode.Y)) Application.Quit();
            
        }
    }

    public void SellOre()
    {
        crypto += FindObjectOfType<OreStorage>().SellOre(crypto);
        Debug.Log($"You have {crypto} crypto");
    }

    public void BuyEnergy(float amountOfEnergy)
    {
        crypto -= FindObjectOfType<Battery>().BuyEnergy(amountOfEnergy, crypto);

    }

    IEnumerator Regen()
    {
        int tempHealth =  FindObjectOfType<Repairment>().Repair(health);
        if(health < 389) 
        {
            yield return new WaitForSeconds(600f);
            health += tempHealth;
        }
        else Debug.Log("Max health");
       
    }

    public void UpgradeCommandC()
    {
        //if(CCLevel < 1 && mainModules >= FindObjectOfType<CommandC>().bodyLimit) return;
        if(CCLevel < 3)levels += 1;
        CCLevel += 1;

        if(CCLevel == 1) mainModules += 1;

        if(CCLevel > 3) 
        {
            Debug.Log("Max Level");
            return;
        }

        if(crypto >= FindObjectOfType<CommandC>().price)
        {
            crypto -= FindObjectOfType<CommandC>().price;
            FindObjectOfType<CommandC>().Level(CCLevel);
            health += FindObjectOfType<CommandC>().health;
            Debug.Log("Command Centre level is " +CCLevel);

        }
        return;
        
    }

    public void UpgradeBody()
    {
        if(BLevel < 1 && mainModules >= FindObjectOfType<CommandC>().bodyLimit)
        {
            Debug.Log("Can not buy body. Buy/Upgrade Command Centre at first!");
            return;
        }

        if(BLevel < 3) levels += 1;
        BLevel += 1;

        if(BLevel == 1) mainModules += 1;

        if(BLevel > 3) 
        {
            Debug.Log("Max Level");
            return;
        }

        if(crypto >= FindObjectOfType<Body>().price)
        {
            crypto -= FindObjectOfType<Body>().price;
            FindObjectOfType<Body>().Level(BLevel);
            health += FindObjectOfType<Body>().health;
            Debug.Log("Body level is " + BLevel);

        }
        return;
    }

    public void UpgradeEngine()
    {
       if(ELevel < 1 && mainModules >= FindObjectOfType<CommandC>().bodyLimit)
        {
            Debug.Log("Can not buy engine. Buy/Upgrade Command Centre at first!");
            return;
        }

        if(ELevel < 3) levels += 1;
        ELevel += 1;

        if(ELevel == 1) mainModules += 1;

        if(ELevel > 3) 
        {
            Debug.Log("Max Level");
            return;
        }

        if(crypto >= FindObjectOfType<Engine>().price)
        {
            crypto -= FindObjectOfType<Engine>().price;
            FindObjectOfType<Engine>().Level(ELevel);
            health += FindObjectOfType<Engine>().health;
            Debug.Log("Engine level is " + ELevel);

        }
        return;
    }

    public void UpgradeBattery()
    {
        if(BatLevel < 1 && mainModules >= FindObjectOfType<CommandC>().bodyLimit)
        {
            Debug.Log("Can not buy battery. Buy/Upgrade Command Centre at first!");
            return;
        }

        if(BatLevel < 3) levels += 1;
        BatLevel += 1;

        if(BatLevel == 1) mainModules += 1;

        if(BatLevel > 3) 
        {
            Debug.Log("Max Level");
            return;
        }

        if(crypto >=FindObjectOfType<Battery>().price)
        {
            crypto -= FindObjectOfType<Battery>().price;
            FindObjectOfType<Battery>().Level(BatLevel);
            health += FindObjectOfType<Battery>().health;
            Debug.Log("Battery level is " + BatLevel);

        }
        return;
    }

    public void UpgradeStorage()
    {
        if(SLevel < 1 && mainModules >= FindObjectOfType<CommandC>().bodyLimit)
        {
            Debug.Log("Can not buy storage. Buy/Upgrade Command Centre at first!");
            return;
        }

        if(SLevel < 3) levels += 1;
        SLevel += 1;

        if(SLevel == 1) mainModules += 1;

        if(SLevel > 3) 
        {
            Debug.Log("Max Level");
            return;
        }

        if(crypto >= OreStorage.FindObjectOfType<OreStorage>().price)
        {
            crypto -= OreStorage.FindObjectOfType<OreStorage>().price;
            OreStorage.FindObjectOfType<OreStorage>().Level(SLevel);
            health += OreStorage.FindObjectOfType<OreStorage>().health;
            Debug.Log("Ore Storage level is " +SLevel);

        }
        return;
    }

    public void UpgradeGun()
    {
        if(GLevel < 1 && mainModules >= FindObjectOfType<CommandC>().bodyLimit)
        {
            Debug.Log("Can not buy gun. Buy/Upgrade Command Centre at first!");
            return;
        }
        if(GLevel < 3) levels += 1;
        GLevel += 1;
        
        if(GLevel == 1) mainModules += 1;

        if(GLevel > 3) 
        {
            Debug.Log("Max Level");
            return;
        }

        if(crypto >= Gun.FindObjectOfType<Gun>().price)
        {
            crypto -= Gun.FindObjectOfType<Gun>().price;
            Engine.FindObjectOfType<Gun>().Level(GLevel);
            damage +=  Gun.FindObjectOfType<Gun>().damage;
            health += Gun.FindObjectOfType<Gun>().health;
            Debug.Log("Gun level is " + GLevel);

        }
        return;
    }

    public void UpgradeAsteroidCollector()
    {
        if(ACLevel < 1 && mainModules >= FindObjectOfType<CommandC>().bodyLimit)
        {
            Debug.Log("Can not buy Asteroid Collector. Buy/Upgrade Command Centre at first!");
            return;
        }

       if(ACLevel < 3) levels += 1;
        ACLevel += 1;

        if(ACLevel == 1) mainModules += 1;

        if(ACLevel > 3) 
        {
            Debug.Log("Max Level");
            return;
        }

        if(crypto >= AsteroidCollector.FindObjectOfType<AsteroidCollector>().price)
        {
            crypto -= AsteroidCollector.FindObjectOfType<AsteroidCollector>().price;
            AsteroidCollector.FindObjectOfType<AsteroidCollector>().Level(ACLevel);
            health += AsteroidCollector.FindObjectOfType<AsteroidCollector>().health;
            Debug.Log("Asteroid Collector level is " + ACLevel);

        }
        return;
    }

    public void UpgradeConverter()
    {
        if(CLevel < 1 && mainModules >= FindObjectOfType<CommandC>().bodyLimit)
        {
            Debug.Log("Can not buy converter. Buy/Upgrade Command Centre at first!");
            return;
        }

        if(CLevel < 3) levels += 1;
        CLevel += 1;

        if(CLevel == 1) mainModules += 1;

        if(CLevel > 3) 
        {
            Debug.Log("Max Level");
            return;
        }

        if(crypto >= Converter.FindObjectOfType<Converter>().price)
        {
            crypto -= Converter.FindObjectOfType<Converter>().price;
            Converter.FindObjectOfType<Converter>().Level(CLevel);
            health += Converter.FindObjectOfType<Converter>().health;
            Debug.Log("Converter level is " + CLevel);

        }
        return;
    }

    public void UpgradeGenerator()
    {
        if(GenLevel < 1 && mainModules >= FindObjectOfType<CommandC>().bodyLimit)
        {
            Debug.Log("Can not buy generator. Buy/Upgrade Command Centre at first!");
            return;
        }

        if(GenLevel < 3) levels += 1;
        GenLevel += 1;

        if(GenLevel == 1) mainModules += 1;

        if(GenLevel > 3) 
        {
            Debug.Log("Max Level");
            return;
        }

        if(crypto >= Generator.FindObjectOfType<Generator>().price)
        {
            crypto -= Generator.FindObjectOfType<Generator>().price;
            Generator.FindObjectOfType<Generator>().Level(GenLevel);
            health += Generator.FindObjectOfType<Generator>().health;
            Debug.Log("Generator level is " + GenLevel);

        }
        return;
    }
    

    public void UpgradeRepairment()
    {
        if(RLevel < 1 && mainModules >= FindObjectOfType<CommandC>().bodyLimit)
        {
            Debug.Log("Can not buy repairment. Buy/Upgrade Command Centre at first!");
            return;
        }

        if(RLevel < 3) levels += 1;
        RLevel += 1;

        if(RLevel == 1) mainModules += 1;

        if(RLevel > 3) 
        {
            Debug.Log("Max Level");
            return;
        }

        if(crypto >= Repairment.FindObjectOfType<Repairment>().price)
        {
            crypto -= Repairment.FindObjectOfType<Repairment>().price;
            Repairment.FindObjectOfType<Repairment>().Level(RLevel);
            health += Repairment.FindObjectOfType<Repairment>().health;
            Debug.Log("Repairment level is " +RLevel);

        }
        return;
    }


}
