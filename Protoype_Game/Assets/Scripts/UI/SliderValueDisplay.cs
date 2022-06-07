using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SliderValueDisplay : MonoBehaviour
{
    public bool isCameraLock = false;
    //UI in options menu for mouse sensitivity slider
    public static float sensitivityvalue = 250;
    public static int cameralockon = 0;
    private void Start()
    {
        if (!isCameraLock)
        {
            GameObject senslider = GameObject.Find("Sensitivity");
            senslider.GetComponent<Slider>().value = sensitivityvalue;
        }
        else if (isCameraLock)
        {
            GameObject camslider = GameObject.Find("CameraLocked");
            camslider.GetComponent<Slider>().value = cameralockon;
        }
    }
    void Update()
    {
        if (!isCameraLock)
        {
            //checks sens value and updates number accordingly
            GameObject senslider = GameObject.Find("Sensitivity");
            sensitivityvalue = senslider.GetComponent<Slider>().value;
            gameObject.GetComponent<TextMeshProUGUI>().text = "[" + sensitivityvalue + "]";
        }
        else if (isCameraLock)
        {
            //checks cam bool and updates display accordingly
            GameObject camslider = GameObject.Find("CameraLocked");
            cameralockon = (int) camslider.GetComponent<Slider>().value;
            gameObject.GetComponent<TextMeshProUGUI>().text = "[" + cameralockon + "]";
        }
    }
}
