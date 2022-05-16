using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public float score = 0;
    public static float savedscore;
    // Update is called once per frame
    void Update()
    {
        TextMeshProUGUI scoretext = gameObject.GetComponent<TextMeshProUGUI>();
        score += 10 * Time.deltaTime;
        scoretext.text = "Score: [" + ((int)score).ToString() + "]";
    }
    public void LogEnemyKill(float score)
    {
        this.score += score;
    }
    public void saveScore()
    {
        savedscore = score;
    }
}
