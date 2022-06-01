using UnityEngine;
using UnityEngine.UI;


public class UpgradeButton : MonoBehaviour
{
    //UI
    public Text UpgradePriceText;
    public Slider UpgradeBar;
    public Button button;
    //etc.
    public float value;
    public GameObject coininv;
    public int currrentcoincount;
    public string stat;
    public GameObject player;
    private int upgradeprice = 1000;
    private void Start()
    {
        ///changes stat based on given string
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
        //accesses current coin count
        currrentcoincount = coininv.GetComponent<CoinInv>().getCoinCount();
    }
    public void OnClick()
    {
        if (currrentcoincount >= upgradeprice)
        {
            //increases lvl if player has the coins to upgrade
            value += .50f;
            UpgradeBar.value = value;
            coininv.GetComponent<CoinInv>().spendCoins(upgradeprice);
            upgradeprice += 750;
            UpgradePriceText.text = upgradeprice + " coins";
            player.GetComponent<Movement>().SendMessage("set" + stat + "Lvl", value);
            if (value >= UpgradeBar.maxValue)
            {
                //makes color more and more red when the bar is at full
                UpgradeBar.GetComponentInChildren<Image>().color = new Color(UpgradeBar.GetComponentInChildren<Image>().color.r + .03f, UpgradeBar.GetComponentInChildren<Image>().color.g - .03f, UpgradeBar.GetComponentInChildren<Image>().color.b - .03f, UpgradeBar.GetComponentInChildren<Image>().color.a);
            }
        }

    }

    public float getValue()
    {
        return value;
    }
}
