using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bar : MonoBehaviour
{
    public Slider slider;
    public GameObject player;

    public void SetSlider(float value)
    {
        slider.value = value;
    }
}
