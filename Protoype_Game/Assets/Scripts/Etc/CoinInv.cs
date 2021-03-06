using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class CoinInv : MonoBehaviour
{
    private void Start()
    {
        coins = 0;
    }
    public int coinstoaddinconsole = 0;
    public static int coins = 0;
    // Update is called once per frame
    void Update()
    {
        //updates coin counter
        TextMeshProUGUI coinstext = gameObject.GetComponent<TextMeshProUGUI>();
        coinstext.text = "Coins: [" + ((int)coins).ToString() + "]";
        addCoins(coinstoaddinconsole);
    }

    public void addCoins(int value)
    {
        coins += value;
    }

    public int getCoinCount()
    {
        return coins;
    }

    public void spendCoins(int coinsamount)
    {
        coins -= coinsamount;
    }
}
