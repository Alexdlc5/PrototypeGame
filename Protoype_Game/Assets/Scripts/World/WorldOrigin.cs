using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldOrigin : MonoBehaviour
{
    public int offsetx = 0;
    public int offsetz = 0;
    public int currentbiomecount = 0;
    public string currentbiome = "";
    public string startingbiome = "Desert";
    public GameObject loadingscreen;

    public float amp = 1;
    void Start()
    {
        currentbiome = startingbiome;

        //random offset in noise
        offsetx = Random.Range(0, 999);
        offsetz = Random.Range(0, 999);

        //random amplitude
        amp = Random.Range(15, 45);
        loadingscreen.GetComponent<loading>().SendMessage("clear");
    }
    private void Update()
    {
        if (currentbiomecount >= 20)
        {
            currentbiomecount = 0;
            float random = Random.Range(0,3);
            if (random >= 2)
            {
                currentbiome = "Pine";
            } 
            else if (random >= 1)
            {
                currentbiome = "Grass_Planes";
            }
            else if (random >= 0)
            {
                currentbiome = "Desert";
            }
        }
    }
}
