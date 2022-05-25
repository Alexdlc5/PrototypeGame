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
    private bool paindelt = false;
    private float paintime = 0;

    private void Start()
    {
        //sets difficulty
        if (GameObject.FindGameObjectWithTag("WorldOrigin"))
        {
            difficulty = GameObject.FindGameObjectWithTag("WorldOrigin").GetComponent<WorldOrigin>().difficulty;
        }
        //health increased by difficulty
        health = health + difficulty;
        player = GameObject.FindGameObjectWithTag("Player");
        coincounter = GameObject.FindGameObjectWithTag("CoinCounter");
        score = GameObject.FindGameObjectWithTag("Score");
    }

    void Update()
    {
        //checks if health is at or below 0
        if (health <= 0)
        {
            score.GetComponent<Score>().LogEnemyKill(scoreforkill);
            for (int i = 0; i < coinreward / 4; i++)
            {
                Instantiate(coin, transform.position, transform.rotation);
            }
            for (int i = 0; i < 4; i++)
            {
                Instantiate(deathbit, transform.position, transform.rotation);
            }
            Destroy(gameObject);
        }

        //dmg indicator
        if (pain)
        {
            if (!paindelt)
            {
                gameObject.GetComponentInChildren<MeshRenderer>().material.color = new Color(gameObject.GetComponent<MeshRenderer>().material.color.r + 20, gameObject.GetComponent<MeshRenderer>().material.color.b, gameObject.GetComponent<MeshRenderer>().material.color.g, gameObject.GetComponent<MeshRenderer>().material.color.a);
                paindelt = true;
            }
            paintime += Time.deltaTime;
            if (paintime > .07f)
            {
                paindelt = false;
                pain = false;
                paintime = 0;
                gameObject.GetComponentInChildren<MeshRenderer>().material.color = new Color(gameObject.GetComponent<MeshRenderer>().material.color.r - 20, gameObject.GetComponent<MeshRenderer>().material.color.b, gameObject.GetComponent<MeshRenderer>().material.color.g, gameObject.GetComponent<MeshRenderer>().material.color.a);
            }
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
            rb.AddRelativeForce(Vector3.forward * speed);
            time = 0;
        }
        else
        {
            time += Time.deltaTime;
        }
    }

    //changed by projectile after collison
    public void DealDamage(float damagedealt)
    {
        health -= damagedealt;
        pain = true;
    }
}
