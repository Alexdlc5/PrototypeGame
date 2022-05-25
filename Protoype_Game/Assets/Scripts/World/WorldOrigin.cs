using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldOrigin : MonoBehaviour
{
    public bool isArenaMode = false;

    public int offsetx = 0;
    public int offsetz = 0;
    public int currentbiomecount = 0;
    public int currentdifficultycount = 0;
    public int difficulty = 0;
    public string currentbiome = "";
    public string startingbiome = "Oak";
    public GameObject loadingscreen;

    //delays itemplacer so there are not major lag spike from multiple tiles loading all at once
    public Queue<int> itemplacerqueue = new Queue<int>();
    private float queuetimer = 0;
    private int previousadded = 0;

    public float amp = 1;
    void Start()
    {
        if (isArenaMode == false)
        {
            currentbiome = startingbiome;

            //random offset in noise
            offsetx = Random.Range(0, 999);
            offsetz = Random.Range(0, 999);

            //random amplitude
            amp = Random.Range(5, 10);
            loadingscreen.GetComponent<loading>().SendMessage("clear");

            itemplacerqueue.Enqueue(0);
        }
       
    }
    private void Update()
    {
        if (isArenaMode == false)
        {
            //goes thru queue on timer
            queuetimer += Time.deltaTime;
            if (queuetimer > .02 && itemplacerqueue.Count != 1)
            {
                itemplacerqueue.Dequeue();
            }
            else if (itemplacerqueue.Peek() == 1)
            {
                queuetimer = 0;
            }
            //increases difficulty 
            if (currentdifficultycount > 10)
            {
                difficulty++;
                currentdifficultycount = 0;
            }

            if (currentbiomecount >= 5)
            {
                //change biome 
                currentbiomecount = 0;
                //chooses biome based on random int
                float random = Random.Range(0, 3);
                if (random >= 2)
                {
                    currentbiome = "Pine";
                }
                else if (random >= 1)
                {
                    currentbiome = "Oak";
                }
                else if (random >= 0)
                {
                    currentbiome = "Desert";
                }
            }
        }
    }
    //called by item placer to get a spot in the queue 
    public int requestQueue()
    {
        itemplacerqueue.Enqueue(previousadded + 1);
        previousadded++;
        return previousadded + 1;
    }
}
