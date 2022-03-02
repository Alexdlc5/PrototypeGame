using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class CoinInv : MonoBehaviour
{
    public static int coins = 0;
    // Update is called once per frame
    void Update()
    {
        TextMeshProUGUI coinstext = gameObject.GetComponent<TextMeshProUGUI>();
        coinstext.text = "Coins: [" + ((int)coins).ToString() + "]";
    }

    public void addCoins(int value)
    {
        coins += value;
    }
}