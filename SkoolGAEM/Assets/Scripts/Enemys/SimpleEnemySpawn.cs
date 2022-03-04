using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemySpawn : MonoBehaviour
{
    public float time = 5.0f;
    public float settime = 5.0f;
    public GameObject Enemy;
    public GameObject player;
    public GameObject score;
    public GameObject coin;
    public GameObject coincounter;
    public GameObject deathbit;
    
    void Update()
    {
        if (time <= 0.0f)
        {
            GameObject newEnemy = Instantiate(Enemy, transform.position, transform.rotation);
            newEnemy.SendMessage("setPlayer", player);
            newEnemy.SendMessage("setScoreTracker", score);
            newEnemy.SendMessage("setCoinType", coin);
            newEnemy.SendMessage("setCoinCounter", coincounter);
            newEnemy.SendMessage("setDeathBit", deathbit);
            time = settime;
        } 
        else
        {
            time -= 1 * Time.deltaTime;
        }
    }
}
