using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject player;
    public GameObject score;
    public GameObject coin;
    public GameObject coincounter;
    public GameObject projectile;
    public GameObject projectilespawn;
    public int coinreward = 3;
    public float speed = 0;
    private float time = 0;
    private float shootingtime = 0;
    public float health = 1;
    public float scoreforkill = 0;
    public GameObject deathbit;
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
    public void setProjectile(GameObject projectile)
    {
        this.projectile = projectile;
    }

    // Update is called once per frame
    void FixedUpdate()

    {
        if (transform.position.y < -50)
        {
            Destroy(gameObject);
        }
        //checks if health is at or below 0
        if (health <= 0)
        {
            score.SendMessage("LogEnemyKill", scoreforkill);
            for (int i = 0; i < coinreward; i++)
            {
                Instantiate(deathbit, transform.position, transform.rotation);
                GameObject newcoin = Instantiate(coin, transform.position, transform.rotation);
                newcoin.SendMessage("setCounter", coincounter);
                newcoin.SendMessage("setPlayer", player);
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
                rb.AddRelativeForce(Vector3.forward * speed);
                time = 0;
            }
            else if (distanceMoreThan(playerLocation, transform.position, 20) && distanceLessThan(playerLocation, transform.position, 30))
            {
                rb.AddRelativeForce(Vector3.forward * -speed);
                time = 0;
            }
            else
            {
                rb.AddRelativeForce(Vector3.forward * -speed * 3);
                time = 0;
            }
        }
        else
        {
            time += Time.fixedDeltaTime;
        }
        
        if (shootingtime > 3)
        {
            GameObject newprojectile = Instantiate(projectile, projectilespawn.transform.position, projectilespawn.transform.rotation);
            newprojectile.SendMessage("setPlayer", player);
            //projectile ignores collisions with the itself
            Physics.IgnoreCollision(newprojectile.GetComponent<Collider>(), GetComponent<Collider>());
            shootingtime = 0;
        }
        else
        {
            shootingtime += Time.fixedDeltaTime;
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
    }
}
