using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreScript : MonoBehaviour
{
    public GameObject StorePopUp;
    private bool storeactive = false;
    void Update()
    {
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
    void setStoreActive(bool boolean)
    {
        StorePopUp.SetActive(boolean);
        storeactive = boolean;
    } 
}