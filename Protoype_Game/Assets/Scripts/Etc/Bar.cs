using UnityEngine;
using UnityEngine.UI;

public class Bar : MonoBehaviour
{
    //bar that can be set with slider
    public Slider slider;
    public GameObject player;

    public void SetSlider(float value)
    {
        slider.value = value;
    }
}
