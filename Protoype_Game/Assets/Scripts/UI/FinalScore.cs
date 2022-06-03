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
            scoretext.text = "Score: [" + Math.Truncate(Score.savedscore * 100) / 100 + "]\n\nPlayer Levels\nShield: [" + Movement.sheildlvl
            + "]\n" + "Boost: [" + Movement.boostlvl+ "]\nFiring Speed: [" + Movement.firinglvl+ "]\nDamage: ["
            + Movement.damagelvl + "]\nSpeed: [" + Movement.speedlvl+ "]\n\nCoins Lost: " + CoinInv.coins;
        } 
        else
        {
            if (isArenaMode)
            {
                TextMeshProUGUI scoretext = gameObject.GetComponent<TextMeshProUGUI>();
                scoretext.text = "Shield: [" + Movement.sheildlvlarenamode+ "]\n" + "Boost: [" + Movement.boostlvlarenamode + "]\nFiring Speed: [" + Movement.firinglvlarenamode + "]\nDamage: ["
                + Movement.damagelvlarenamode + "]\nSpeed: [" + Movement.speedlvlarenamode + "]";
            }
            else
            {
                TextMeshProUGUI scoretext = gameObject.GetComponent<TextMeshProUGUI>();
                scoretext.text = "Shield: [" + Movement.sheildlvlinfinite + "]\n" + "Boost: [" + Movement.boostlvlinfinite + "]\nFiring Speed: [" + Movement.firinglvlinfinite + "]\nDamage: ["
                + Movement.damagelvlinfinite + "]\nSpeed: [" + Movement.speedlvlinfinite + "]";
            }
        }
    }
}
