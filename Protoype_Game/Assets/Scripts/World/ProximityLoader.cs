using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProximityLoader : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //checks for nearby enenmys and spanwers and activates them
        if (other.gameObject.tag == "Spawner")
        {
            if (other.gameObject.GetComponentInParent<SimpleEnemySpawn>())
            {
                other.gameObject.GetComponentInParent<SimpleEnemySpawn>().setSpawnerActive(true);
            }
            else
            {
                other.gameObject.GetComponentInParent<ShootingEnemySpawner>().setSpawnerActive(true);
            }
        }
        if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "Boss")
        {
            other.gameObject.GetComponentInParent<WorldObject>().setVis(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //checks for nearby enenmys and spanwers and deactivates them
        if (other.gameObject.tag == "Spawner")
        {
            if (other.gameObject.GetComponentInParent<SimpleEnemySpawn>())
            {
                other.gameObject.GetComponentInParent<SimpleEnemySpawn>().setSpawnerActive(false);
            }
            else
            {
                other.gameObject.GetComponentInParent<ShootingEnemySpawner>().setSpawnerActive(false);
            }
        }
        if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "Boss")
        {
            other.gameObject.GetComponentInParent<WorldObject>().setVis(false);
        }
    }
}
