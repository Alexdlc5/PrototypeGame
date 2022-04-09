using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SliderValueDisplay : MonoBehaviour
{
    public static float sensitivityvalue = 250;
    private void Start()
    {
        GameObject senslider = GameObject.Find("Sensitivity");
        senslider.GetComponent<Slider>().value = sensitivityvalue;
    }
    void Update()
    {
        GameObject senslider = GameObject.Find("Sensitivity");
        sensitivityvalue = senslider.GetComponent<Slider>().value;
        gameObject.GetComponent<TextMeshProUGUI>().text = "[" + sensitivityvalue + "]";
    }
}
