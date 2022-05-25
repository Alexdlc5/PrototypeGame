using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemySpawner : MonoBehaviour
{
    public float time = 5.0f;
    public float settime = 5.0f;
    public int enemyspawncount = 4;
    public bool inloadingdistance;
    public bool spawneractive;
    public GameObject Enemy;

    void Update()
    {  
        //if in range of player 
        if (enemyspawncount >= 0)
        {
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


