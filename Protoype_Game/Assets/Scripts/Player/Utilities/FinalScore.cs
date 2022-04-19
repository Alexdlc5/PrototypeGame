using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinalScore : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        TextMeshProUGUI scoretext = gameObject.GetComponent<TextMeshProUGUI>();
        scoretext.text = "Score: [" + Score.savedscore + "]\n\n[Player Levels]\nSheild: [" + Movement.sheildlvl + "]\n" + "Boost: [" + (double)Movement.boostlvl + "]\nFiring Speed: [" + (double)Movement.firinglvl +"]\nDamage: [" + (double)Movement.damagelvl + "]\nSpeed: [" + (double)Movement.speedlvl + "]";
    }
}
