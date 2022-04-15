using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemySpawner : MonoBehaviour
{
    public float time = 5.0f;
    public float settime = 5.0f;
    public bool inloadingdistance;
    public GameObject Enemy;
    public GameObject player;
    public GameObject score;
    public GameObject coin;
    public GameObject coincounter;
    public GameObject deathbit;
    public GameObject projectile;

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
            newEnemy.SendMessage("setProjectile", projectile);
            time = settime;
        }
        else
        {
            time -= 1 * Time.deltaTime;
        }
    }
}

