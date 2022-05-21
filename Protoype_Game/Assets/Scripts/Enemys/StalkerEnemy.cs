using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StalkerEnemy : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject player;
    public GameObject score;
    public GameObject coin;
    public GameObject coincounter;
    public GameObject deathbit;
    public int difficulty = 0;
    public int coinreward = 3;
    public float speed = 0;
    public float time = 0;
    public float health = 1;
    public float scoreforkill = 0;

    private bool pain = false;
    private bool paindelt = false;
    private float paintime = 0;

    private void Start()
    {
        difficulty = GameObject.FindGameObjectWithTag("WorldOrigin").GetComponent<WorldOrigin>().difficulty;
        health = health + difficulty * .90f;
        player = GameObject.FindGameObjectWithTag("Player");
        coincounter = GameObject.FindGameObjectWithTag("CoinCounter");
        score = GameObject.FindGameObjectWithTag("Score");
    }
    public void setCoinType(GameObject coin)
    {
        this.coin = coin;
    }
    public void setDeathBit(GameObject deathbit)
    {
        this.deathbit = deathbit;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //work on dmg indicator
        if (pain)
        {
            if (!paindelt)
            {
                gameObject.GetComponent<MeshRenderer>().material.color = new Color(gameObject.GetComponent<MeshRenderer>().material.color.r + 20, gameObject.GetComponent<MeshRenderer>().material.color.b, gameObject.GetComponent<MeshRenderer>().material.color.g, gameObject.GetComponent<MeshRenderer>().material.color.a);
                paindelt = true;
            }
            paintime += Time.deltaTime;
            if (paintime > .07f)
            {
                paindelt = false;
                pain = false;
                paintime = 0;
                gameObject.GetComponent<MeshRenderer>().material.color = new Color(gameObject.GetComponent<MeshRenderer>().material.color.r - 20, gameObject.GetComponent<MeshRenderer>().material.color.b, gameObject.GetComponent<MeshRenderer>().material.color.g, gameObject.GetComponent<MeshRenderer>().material.color.a);
            }
        }
        if (transform.position.y < -50)
        {
            Destroy(gameObject);
        }
        //checks if health is at or below 0
        if (health <= 0)
        {
            score.GetComponent<Score>().LogEnemyKill(scoreforkill);
            for (int i = 0; i < coinreward/4; i++)
            {
                Instantiate(coin, transform.position, transform.rotation);
            }
            for (int i = 0; i < 4; i++)
            {
                Instantiate(deathbit, transform.position, transform.rotation);
            }
            Destroy(gameObject);
        }

        Vector3 playerLocation = player.transform.position;
        
        //look at player
        transform.LookAt(new Vector3(playerLocation[0], transform.position.y, playerLocation[2]));
        
        //move toward player at various speeds when at diffrent distances
        if (time >= .1)
        {
            if (distanceMoreThan(playerLocation, transform.position, 30))
            {
                rb.AddRelativeForce(Vector3.forward * speed * 50);
                time = 0;
            }
            else if (distanceMoreThan(playerLocation, transform.position, 20) && distanceLessThan(playerLocation, transform.position, 30))
            {
                rb.AddRelativeForce(Vector3.forward * speed * 500);
                time = 0;
            }
            else
            {
                rb.AddRelativeForce(Vector3.forward * speed * 850);
                time = 0;
            }

        }
        else
        {
            time += 1 * Time.deltaTime;
        }

    }
   
    //returns true if enemy is close to player (close defined by the float)
    public bool distanceMoreThan(Vector3 playerLocation, Vector3 enemyPosition, float distance)
    {
        if (playerLocation[0] - enemyPosition[0] >= distance || playerLocation[0] - enemyPosition[0] <= -distance)
        {
            return true;
        }
        else if (playerLocation[2] - enemyPosition[2] >= distance || playerLocation[2] - enemyPosition[2] <= -distance)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
   
    //returns true if enemy is close to player (close defined by the float)
    public bool distanceLessThan(Vector3 playerLocation, Vector3 enemyPosition, float distance)
    {
        if (playerLocation[0] - enemyPosition[0] < distance || playerLocation[0] - enemyPosition[0] > -distance)
        {
            if (playerLocation[2] - enemyPosition[2] < distance || playerLocation[2] - enemyPosition[2] > -distance)
            {
                return true;
            }
            return false;
        }
        else
        {
            return false;
        }
    }
    
    //changed by projectile after collison
    public void DealDamage(float damagedealt)
    {
        health -= damagedealt;
        pain = true;
    }
}
