using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemySpawn : MonoBehaviour
{
    public float time = 5.0f;
    public float settime = 5.0f;
    public bool inloadingdistance = false;
    public bool spawneractive = false;
    public GameObject Enemy;

    void Update()
    {
        if (gameObject.GetComponent<WorldObject>())
        {
            inloadingdistance = gameObject.GetComponent<WorldObject>().visstate;
        }
        if (time <= 0.0f && inloadingdistance && spawneractive)
        {
            Instantiate(Enemy, transform.position, transform.rotation);
            time = settime;
        } 
        else
        {
            time -= 1 * Time.deltaTime;
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
