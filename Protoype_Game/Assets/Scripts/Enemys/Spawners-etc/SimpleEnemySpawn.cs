using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemySpawn : MonoBehaviour
{
    public float time = 5.0f;
    public float settime = 5.0f;
    public int enemyspawncount = 4;
    public bool inloadingdistance = false;
    public bool spawneractive = false;
    public GameObject Enemy;
    private float difficultytimemult;
    private WorldOrigin worldorigin;
    private void Start()
    {
        worldorigin = GameObject.FindGameObjectWithTag("WorldOrigin").GetComponent<WorldOrigin>();
        difficultytimemult = 1 - worldorigin.difficulty * 1.5f / 100;

        settime *= difficultytimemult;
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
            if (time <= 0.0f && inloadingdistance && spawneractive)
            {
                Instantiate(Enemy, transform.position, transform.rotation);
                enemyspawncount--;
                time = settime;
            }
            else
            {
                time -= 1 * Time.deltaTime;
            }
        } 
        else
        {
            Destroy(gameObject);
        }
    }
    public void setParent(Transform newparent)
    {
        transform.parent = newparent;
    }

    public void setSpawnerActive(bool boolean)
    {
        spawneractive = boolean;
    }
}
