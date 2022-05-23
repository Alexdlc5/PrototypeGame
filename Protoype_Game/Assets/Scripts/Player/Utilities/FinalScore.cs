using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class FinalScore : MonoBehaviour
{
    // Start is called before the first frame update
    public bool inMainMenu = false;
    public bool isArenaMode = false;
    void Start()
    {
        if (!inMainMenu)
        {
            TextMeshProUGUI scoretext = gameObject.GetComponent<TextMeshProUGUI>();
            scoretext.text = "Score: [" + Math.Truncate(Score.savedscore * 100) / 100 + "]\n\nPlayer Levels\nShield: [" + Movement.sheildlvl * 4
            + "]\n" + "Boost: [" + Movement.boostlvl * 4 + "]\nFiring Speed: [" + Movement.firinglvl * 4 + "]\nDamage: ["
            + Movement.damagelvl * 4 + "]\nSpeed: [" + Movement.speedlvl * 4 + "]\n\nCoins Lost\nCoins: " + CoinInv.coins;
        } 
        else
        {
            if (isArenaMode)
            {
                TextMeshProUGUI scoretext = gameObject.GetComponent<TextMeshProUGUI>();
                scoretext.text = "Shield: [" + Movement.sheildlvlarenamode * 4 + "]\n" + "Boost: [" + Movement.boostlvlarenamode * 4 + "]\nFiring Speed: [" + Movement.firinglvlarenamode * 4 + "]\nDamage: ["
                + Movement.damagelvlarenamode * 4 + "]\nSpeed: [" + Movement.speedlvlarenamode * 4 + "]";
            }
            else
            {
                TextMeshProUGUI scoretext = gameObject.GetComponent<TextMeshProUGUI>();
                scoretext.text = "Shield: [" + Movement.sheildlvlinfinite * 4 + "]\n" + "Boost: [" + Movement.boostlvlinfinite * 4 + "]\nFiring Speed: [" + Movement.firinglvlinfinite * 4 + "]\nDamage: ["
                + Movement.damagelvlinfinite * 4 + "]\nSpeed: [" + Movement.speedlvlinfinite * 4 + "]";
            }
        }
    }
}
