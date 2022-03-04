using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemy : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject player;
    public GameObject score;
    public GameObject coin;
    public GameObject coincounter;
    public GameObject deathbit;
    public float speed = 0;
    public int coinreward = 1;
    public float time = 0;
    public float health = 1;
    public float scoreforkill = 0;

    //set targetplayer
    public void setPlayer(GameObject player)
    {
        this.player = player;
    }
    public void setScoreTracker(GameObject score)
    {
        this.score = score;
    }
    public void setCoinType(GameObject coin)
    {
        this.coin = coin;
    }
    public void setCoinCounter(GameObject coincounter)
    {
        this.coincounter = coincounter;
    }
    public void setDeathBit(GameObject deathbit)
    {
        this.deathbit = deathbit;
    }

    void Update()
    {
        Debug.DrawLine(transform.position, player.transform.position, Color.yellow);
        Vector3 playerLocation = player.transform.position;
        transform.LookAt(new Vector3(playerLocation[0], transform.position.y, playerLocation[2]));
        if (time >= .75) 
        {
            rb.AddRelativeForce(Vector3.forward * speed);
            time = 0;
        }
        else
        {
            time += 1 * Time.deltaTime;
        }

        //checks if health is at or below 0
        if (health <= 0)
        {
            score.SendMessage("LogEnemyKill", scoreforkill);
            for (int i = 0; i < coinreward; i++)
            {
                GameObject newcoin = Instantiate(coin, transform.position, transform.rotation);
                Instantiate(deathbit, transform.position, transform.rotation);
                newcoin.SendMessage("setCounter", coincounter);
                newcoin.SendMessage("setPlayer", player);
            }
            Destroy(gameObject);
        }
    }

    //changed by projectile after collison
    public void DealDamage(float damagedealt)
    {
        health -= damagedealt;
    }
}
