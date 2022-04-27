using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonGenerator : MonoBehaviour
{
    public GameObject room;
    public float newroomoffset = 0;
    public GameObject worldorigin;
    public GameObject player;
    void GenerateDungeon()
    {
        //worldorigin.GetComponent<WorldOrigin>().dungeonLocations
        transform.position = new Vector3(player.transform.position.x, -90, player.transform.position.z + newroomoffset);
        //if there is not dungeon at this position(not done)
        if (worldorigin.GetComponent<WorldOrigin>())
        {
            Instantiate(room);
            newroomoffset = 0;
            player.transform.position = transform.position;
        }
        //if there is a dungeon at this position
        else
        {
            newroomoffset += 100;
            GenerateDungeon();
        }
    }
}
