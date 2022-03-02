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
        scoretext.text = "[Score: " + ((int)Score.savedscore).ToString() + "]";
    }
}
