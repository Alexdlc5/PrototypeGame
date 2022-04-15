using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemySpawn : MonoBehaviour
{
    public float time = 5.0f;
    public float settime = 5.0f;
    public bool inloadingdistance = false;
    public GameObject Enemy;
    public GameObject player;
    public GameObject score;
    public GameObject coin;
    public GameObject coincounter;
    public GameObject deathbit;

    private void Start()
    {
        score = GameObject.FindGameObjectWithTag("Score");
    }
    void Update()
    {
        if (gameObject.GetComponent<WorldObject>())
        {
            inloadingdistance = gameObject.GetComponent<WorldObject>().visstate;
        }
        if (time <= 0.0f && inloadingdistance)
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

    public void setPlayer()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        coincounter = GameObject.FindGameObjectWithTag("CoinCounter");
    }

    public void setParent(Transform newparent)
    {
        transform.parent = newparent;
    }
}
