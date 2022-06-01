using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemySpawn : MonoBehaviour
{
    //timers
    public float time = 5.0f;
    public float settime = 5.0f;
    public int enemyspawncount = 4;
    //loading in and out 
    public bool inloadingdistance = false;
    public bool spawneractive = false;
    //etc.
    public GameObject Enemy;
    private float difficultytimemultiplier;
    private WorldOrigin worldorigin;
    private void Start()
    {
        worldorigin = GameObject.FindGameObjectWithTag("WorldOrigin").GetComponent<WorldOrigin>();
        //as difficulty increases: spawn speed increases, spawn count increases
        difficultytimemultiplier = 1 - worldorigin.difficulty * 1.5f / 100;
        settime *= difficultytimemultiplier;
        enemyspawncount += worldorigin.difficulty * 2;
    }
    void Update()
    {
        if (enemyspawncount >= 0)
        {
            //if player is in range spanwn enemys every x seconds
            if (gameObject.GetComponent<WorldObject>())
            {
                inloadingdistance = gameObject.GetComponent<WorldObject>().visstate;
            }
            //player is in range spawn enemys
            if (time <= 0.0f && inloadingdistance && spawneractive)
            {
                Instantiate(Enemy, transform.position, transform.rotation);
                enemyspawncount--;
                time = settime;
            }
            //change timer if time is not 0
            else
            {
                time -= 1 * Time.deltaTime;
            }
        }
        //if enemy is out of range for certain amout of time, despawn
        else
        {
            Destroy(gameObject);
        }
    }
    //sets parent in hierarchy
    public void setParent(Transform newparent)
    {
        transform.parent = newparent;
    }
    //sets wheather or not the spawner is active
    public void setSpawnerActive(bool boolean)
    {
        spawneractive = boolean;
    }
}
