using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreScript : MonoBehaviour
{
    public GameObject StorePopUp;
    public bool storeactive = false;
    void Update()
    {
        //opens and closes menu at button push
        if (Input.GetKeyDown(KeyCode.L) && storeactive == false)
        {
            StorePopUp.SetActive(true);
            storeactive = true;
        } 
        else if (Input.GetKeyDown(KeyCode.L) && storeactive == true)
        {
            StorePopUp.SetActive(false);
            storeactive = false;
        }
    }
}
