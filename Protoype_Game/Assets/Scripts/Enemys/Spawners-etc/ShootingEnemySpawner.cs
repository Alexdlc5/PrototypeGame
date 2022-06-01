using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemySpawner : MonoBehaviour
{
    //timers
    public float time = 5.0f;
    public float settime = 5.0f;
    public int enemyspawncount = 4;
    //loading
    public bool inloadingdistance;
    public bool spawneractive;
    //etc.
    public GameObject Enemy;
    private float difficultytimemult;
    private WorldOrigin worldorigin;
    private void Start()
    {
        worldorigin = GameObject.FindGameObjectWithTag("WorldOrigin").GetComponent<WorldOrigin>();
        //difficulty increases spawn speed and spawn count
        difficultytimemult = 1 - worldorigin.difficulty * 1.5f / 100;
        settime *= difficultytimemult;
        enemyspawncount += worldorigin.difficulty * 2;
    }
    void Update()
    {  
        //if in range of player 
        if (enemyspawncount >= 0)
        {
            //sets if in loading distance
            if (gameObject.GetComponent<WorldObject>())
            {
                inloadingdistance = gameObject.GetComponent<WorldObject>().visstate;
            }
            //if in range and time to spawn, spawn 
            if (time <= 0.0f && inloadingdistance && spawneractive)
            {
                Instantiate(Enemy, transform.position, transform.rotation);
                enemyspawncount--;
                time = settime;
            }
            //changes timer if timer not 0
            else
            {
                time -= 1 * Time.deltaTime;
            }
        }
        //if out of loading diastance for certain amount of time despawn
        else
        {
            Destroy(gameObject);
        }
    }
    //sets parent in heirarchy
    public void setParent(Transform newparent)
    {
        transform.parent = newparent;
    }
    //sets wheather or not spawner is active
    public void setSpawnerActive(bool boolean)
    {
        spawneractive = boolean;
    }
}


