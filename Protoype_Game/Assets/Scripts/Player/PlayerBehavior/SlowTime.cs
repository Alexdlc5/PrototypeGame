using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowTime : MonoBehaviour
{
    private bool windowopen = false;
    private bool pausewindowopen = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L) && windowopen == false && pausewindowopen == false)
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
        if (Input.GetKeyDown(KeyCode.Escape) && pausewindowopen == false && windowopen == false)
        {
            //slowtime
            Time.timeScale = 0;
            pausewindowopen = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && pausewindowopen == true)
        {
            //speed up time
            Time.timeScale = 1f;
            pausewindowopen = false;
        }
        Time.fixedDeltaTime = Time.timeScale * .02f;
    }
}
