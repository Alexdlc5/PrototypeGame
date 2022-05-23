using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UpgradeButton : MonoBehaviour
{
    public Slider UpgradeBar;
    public Button button;
    public float value;
    public GameObject coininv;
    public int currrentcoincount;
    public string stat;
    public GameObject player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        currrentcoincount = coininv.GetComponent<CoinInv>().getCoinCount();
        if (stat.Equals("Sheild"))
        {
            value = Movement.sheildlvl;
        } 
        else if (stat.Equals("Boost"))
        {
            value = Movement.boostlvl;
        }
        else if (stat.Equals("Firing"))
        {
            value = Movement.firinglvl;
        }
        else if (stat.Equals("Damage"))
        {
            value = Movement.damagelvl;
        }
        else if (stat.Equals("Speed"))
        {
            value = Movement.speedlvl;
        }
        UpgradeBar.value = value;
    }
    private void Update()
    {
        currrentcoincount = coininv.GetComponent<CoinInv>().getCoinCount();
    }
    public void OnClick()
    {
        if (currrentcoincount >= 1000)
        {
            value += .25f;
            UpgradeBar.value = value;
            coininv.GetComponent<CoinInv>().spendCoins(1000);
            player.GetComponent<Movement>().SendMessage("set" + stat + "Lvl", value);
            if (value >= UpgradeBar.maxValue)
            {
                UpgradeBar.GetComponentInChildren<Image>().color = new Color(UpgradeBar.GetComponentInChildren<Image>().color.r + .03f, UpgradeBar.GetComponentInChildren<Image>().color.g - .03f, UpgradeBar.GetComponentInChildren<Image>().color.b - .03f, UpgradeBar.GetComponentInChildren<Image>().color.a);
            }
        }

    }

    public float getValue()
    {
        return value;
    }
}
