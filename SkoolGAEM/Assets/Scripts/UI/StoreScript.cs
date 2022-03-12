using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreScript : MonoBehaviour
{
    public GameObject StorePopUp;
    private bool storeactive = false;

    public GameObject sheild;
    public GameObject boost;
    public GameObject firing;
    public GameObject damage;
    public GameObject speed;

    public float sheildvalue;
    public float boostvalue;
    public float firingvalue;
    public float damagevalue;
    public float speedvalue;
    private void Start()
    {
        //sets values
        sheildvalue = sheild.GetComponent<UpgradeButton>().value;
        boostvalue = boost.GetComponent<UpgradeButton>().value;
        firingvalue = firing.GetComponent<UpgradeButton>().value;
        damagevalue = damage.GetComponent<UpgradeButton>().value;
        speedvalue = speed.GetComponent<UpgradeButton>().value;
    }
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
}
