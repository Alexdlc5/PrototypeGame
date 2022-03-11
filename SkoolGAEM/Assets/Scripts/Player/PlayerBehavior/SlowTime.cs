using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowTime : MonoBehaviour
{
    public bool windowopen = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L) && windowopen == false)
        {
            //slowtime
            Time.timeScale = .5f;
            windowopen = true;
        } 
        else if (Input.GetKeyDown(KeyCode.L) && windowopen == true)
        {
            //speed up time
            Time.timeScale = 1f;
            windowopen = false;
        }
    }
}
