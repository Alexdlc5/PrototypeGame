using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldOrigin : MonoBehaviour
{
    public int offsetx = 0;
    public int offsetz = 0;

    public float amp = 1;
    void Start()
    {
        //random offset in noise
        offsetx = Random.Range(0, 999);
        offsetz = Random.Range(0, 999);

        //random amplitude
        amp = Random.Range(15, 35);
    }
}
