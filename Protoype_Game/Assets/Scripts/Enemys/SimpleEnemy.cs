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
    public int difficulty = 0;
    public float speed = 0;
    public int coinreward = 1;
    public float time = 0;
    public float health = 1;
    public float scoreforkill = 0;
    private bool pain = false;

    private void Start()
    {
        //sets difficulty 
        difficulty = GameObject.FindGameObjectWithTag("WorldOrigin").GetComponent<WorldOrigin>().difficulty;
        //health increased by difficulty
        health = health + difficulty;
    }

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
        if (pain)
        {
            gameObject.GetComponent<Material>
        }
        //despawns if lower than -50
        if (transform.position.y < -50)
        {
            Destroy(gameObject);
        }
        //faces player and move toward them
        Vector3 playerLocation = player.transform.position;
        transform.LookAt(new Vector3(playerLocation[0], transform.position.y, playerLocation[2]));
        if (time >= .75) 
        {
            //increases speed by difficulty
            rb.AddRelativeForce(Vector3.forward * (float)(speed + difficulty / 2));
            time = 0;
        }
        else
        {
            time += difficulty / 5 + Time.deltaTime;
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
        pain = true;
    }
}
