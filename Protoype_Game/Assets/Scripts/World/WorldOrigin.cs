using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldOrigin : MonoBehaviour
{
    public int offsetx = 0;
    public int offsetz = 0;
    public int currentbiomecount = 0;
    public int difficulty = 0;
    public string currentbiome = "";
    public string startingbiome = "Oak";
    public GameObject loadingscreen;

    public Queue<int> itemplacerqueue = new Queue<int>();
    private float queuetimer = 0;
    private int previousadded = 0;

    public float amp = 1;
    void Start()
    {
        currentbiome = startingbiome;

        //random offset in noise
        offsetx = Random.Range(0, 999);
        offsetz = Random.Range(0, 999);

        //random amplitude
        amp = Random.Range(15, 20);
        loadingscreen.GetComponent<loading>().SendMessage("clear");

        itemplacerqueue.Enqueue(0);

        if (currentbiomecount >= 12)
        {
            //increase difficulty and change biome
            difficulty++;
            currentbiomecount = 0;
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
    private void Update()
    {
        queuetimer += Time.deltaTime;
        if (queuetimer > .02 && itemplacerqueue.Count != 1)
        {
            itemplacerqueue.Dequeue();
        }
        else if (itemplacerqueue.Peek() == 1)
        {
            queuetimer = 0;
        }
    }

    public int requestQueue()
    {
        itemplacerqueue.Enqueue(previousadded + 1);
        previousadded++;
        return previousadded + 1;
    }
}
