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
        currrentcoincount = coininv.GetComponent<CoinInv>().getCoinCount();
        value = 0;
        UpgradeBar.value = 0;
    }
    private void Update()
    {
        currrentcoincount = coininv.GetComponent<CoinInv>().getCoinCount();
    }
    public void OnClick()
    {
        if (currrentcoincount >= 1000)
        {
            value++;
            UpgradeBar.value = value;
            coininv.GetComponent<CoinInv>().spendCoins(1000);
            player.SendMessage("set" + stat + "Lvl", value);
        }

    }

    public float getValue()
    {
        return value;
    }
}
