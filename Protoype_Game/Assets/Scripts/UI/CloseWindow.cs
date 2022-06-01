using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
//close popup button
public class CloseWindow : MonoBehaviour
{
    public Button button;
    public GameObject PopUp;
    void Update()
    {
        button.onClick.AddListener(ClosePopUp);
    }

    void ClosePopUp()
    {
        PopUp.SendMessage("setStoreActive", false);
    }
}
