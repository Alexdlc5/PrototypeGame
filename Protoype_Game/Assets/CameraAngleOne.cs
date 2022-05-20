using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CameraAngleOne : MonoBehaviour
{
    public static float cameravalue = 0;
    private void Start()
    {
        GameObject cameraslider = GameObject.Find("Camera Type");
        cameraslider.GetComponent<Slider>().value = cameravalue;
    }
    void Update()
    {
        GameObject cameraslider = GameObject.Find("Camera Type");
        cameravalue = cameraslider.GetComponent<Slider>().value;
        if (cameravalue == 0)
        {
            gameObject.GetComponent<TextMeshProUGUI>().text = "[close follow]";
        } 
        else
        {
            gameObject.GetComponent<TextMeshProUGUI>().text = "[topdown]";
        }
    }
}
