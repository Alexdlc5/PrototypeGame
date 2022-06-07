using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Camera camera0;
    public Camera camera1;
    // Start is called before the first frame update
    void Start()
    {
        if (SliderValueDisplay.cameralockon == 0)
        {
            camera1.GetComponent<CameraFollow>().isActiveCam = false;
        } 
        else
        {
            camera0.GetComponent<CameraFollow>().isActiveCam = false;
        }
    }
}
