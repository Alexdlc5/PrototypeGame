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
        //displays final score
        if (!inMainMenu)
        {
            TextMeshProUGUI scoretext = gameObject.GetComponent<TextMeshProUGUI>();
            scoretext.text = "Score: [" + Math.Truncate(Score.savedscore * 100) / 100 + "]\n\nPlayer Levels\nShield: [" + Movement.sheildlvl * 2
            + "]\n" + "Boost: [" + Movement.boostlvl * 2 + "]\nFiring Speed: [" + Movement.firinglvl * 2 + "]\nDamage: ["
            + Movement.damagelvl * 2 + "]\nSpeed: [" + Movement.speedlvl * 2 + "]\n\nCoins Lost: " + CoinInv.coins;
        } 
        else
        {
            if (isArenaMode)
            {
                TextMeshProUGUI scoretext = gameObject.GetComponent<TextMeshProUGUI>();
                scoretext.text = "Shield: [" + Movement.sheildlvlarenamode * 2 + "]\n" + "Boost: [" + Movement.boostlvlarenamode * 2 + "]\nFiring Speed: [" + Movement.firinglvlarenamode * 2 + "]\nDamage: ["
                + Movement.damagelvlarenamode * 2 + "]\nSpeed: [" + Movement.speedlvlarenamode * 2 + "]";
            }
            else
            {
                TextMeshProUGUI scoretext = gameObject.GetComponent<TextMeshProUGUI>();
                scoretext.text = "Shield: [" + Movement.sheildlvlinfinite * 2 + "]\n" + "Boost: [" + Movement.boostlvlinfinite * 2 + "]\nFiring Speed: [" + Movement.firinglvlinfinite * 2 + "]\nDamage: ["
                + Movement.damagelvlinfinite * 2 + "]\nSpeed: [" + Movement.speedlvlinfinite * 2 + "]";
            }
        }
    }
}
