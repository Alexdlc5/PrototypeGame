using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SliderValueDisplay : MonoBehaviour
{
    //UI in options menu for mouse sensitivity slider
    public static float sensitivityvalue = 250;
    private void Start()
    {
        GameObject senslider = GameObject.Find("Sensitivity");
        senslider.GetComponent<Slider>().value = sensitivityvalue;
    }
    void Update()
    {
        //checks sens value and updates number accordingly
        GameObject senslider = GameObject.Find("Sensitivity");
        sensitivityvalue = senslider.GetComponent<Slider>().value;
        gameObject.GetComponent<TextMeshProUGUI>().text = "[" + sensitivityvalue + "]";
    }
}
