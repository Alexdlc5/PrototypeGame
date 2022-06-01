using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBit : MonoBehaviour
{
    float time = 0;
    void Update()
    {
        //despawns afetr certain amount of time
        if (time > 5)
        {
            GetComponent<BoxCollider>().enabled = false;
            Destroy(gameObject, 2f);
        }
        else
        {
           time += Time.deltaTime;
        }
    }
}
