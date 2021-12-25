using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;

public class Fight : MonoBehaviour
{
    private int fightCounter = 1;
    private bool playerTurn = false;
    public bool isFight = false;
    string docName;

    private PlayerStats ps;
    private EnemyStats es;
    private AsteroidSpawner spawner;
    // Start is called before the first frame update

    private void Awake() {

        if(Directory.Exists(Application.streamingAssetsPath))
        {
            FileUtil.DeleteFileOrDirectory(Application.streamingAssetsPath);
            AssetDatabase.Refresh();
        }
    }
    void Start()
    {
        spawner = FindObjectOfType<AsteroidSpawner>();
        Directory.CreateDirectory(Application.streamingAssetsPath + "/Battles/");
    }

    public void StartFight()
    {
        docName = CreateTextFile();

        ps = FindObjectOfType<PlayerStats>();
        es = FindObjectOfType<EnemyStats>();

        isFight = true;
        CreateTextFile();
        File.AppendAllText(docName, "Your ship stats:  " + "health: "+ ps.health.ToString() + ", damage: " + ps.damage.ToString()
                                  + "\nEnemy stats: "  + "health: " + es.health.ToString() + ", damage: " + es.damage.ToString() + '\n');

        FindObjectOfType<Battery>().currentCapacity -= FindObjectOfType<Engine>().battle;
        StartCoroutine(EnemyTurn()); 
 
    }

    private IEnumerator PlayerTurn()
    {
        Debug.Log("It's your turn\nPress left mouse button to shoot");
        yield return new WaitForSeconds(1f);
        if(Input.GetMouseButton(0)) yield return new WaitForSeconds(3f);
        es.health -= ps.damage;
        FindObjectOfType<Battery>().currentCapacity -= FindObjectOfType<Engine>().battle;
        File.AppendAllText(docName, "Your ship damaged enemy: " + ps.damage.ToString() + " , Enemy current health is: " + es.health.ToString() + '\n');

        if(es.health <= 0)
        {
            EndBattle();
        }
        else
        {
            playerTurn = false;
            Debug.Log($"Enemy was hit, damage {ps.damage}");
            StartCoroutine(EnemyTurn());

        }
        
    }

    private IEnumerator EnemyTurn()
    {
        Debug.Log("Enemy turn");
        yield return new WaitForSeconds(2f);
        ps.health -= es.damage;
        File.AppendAllText(docName, "Enemy damaged your ship: " + es.damage.ToString() + " , Ship current health is: " + ps.health.ToString() + '\n');
        if(ps.health <= 0)
        {
            EndBattle();
        } 
        else 
        {
            playerTurn = true;
            Debug.Log($"Player was hit, damage {es.damage}");
            StartCoroutine(PlayerTurn());

        }
      
    }

    private void EndBattle()
    {
        if(ps.health <= 0) 
        {
            Debug.Log("Your ship was destroyed");
            File.AppendAllText(docName, "Your ship was destroyed");
            fightCounter += 1;
            Application.Quit();
        }
        else if(es.health <= 0)
        {
            File.AppendAllText(docName, "You won!");
            Debug.Log("You are the winner in this battle");
            Destroy(es.gameObject);
            if(fightCounter % 3 == 0) spawner.Spawn();
            FindObjectOfType<Battery>().currentCapacity += 100;
            fightCounter += 1;
            isFight = false;
        }
        

    }

    private string CreateTextFile()
    {
        string textDocName = Application.streamingAssetsPath + "/Battles/" + "Battle" + fightCounter.ToString() + ".txt";

        if(!File.Exists(textDocName))
        {
            File.WriteAllText(textDocName, "Info of " + fightCounter.ToString() + "\n");
        }

        return textDocName;
    }

}
