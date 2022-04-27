using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class FinalScore : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        TextMeshProUGUI scoretext = gameObject.GetComponent<TextMeshProUGUI>();
        scoretext.text = "Score: [" + Math.Truncate(Score.savedscore * 100) / 100  + "]\n\nPlayer Levels\nSheild: [" + Movement.sheildlvl
            + "]\n" + "Boost: [" + Movement.boostlvl + "]\nFiring Speed: [" + Movement.firinglvl + "]\nDamage: [" 
            + Movement.damagelvl + "]\nSpeed: [" + Movement.speedlvl + "]\n\nCoins Lost\nCoins: " + CoinInv.coins;
    }
}
