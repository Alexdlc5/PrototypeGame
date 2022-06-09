using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldOrigin : MonoBehaviour
{
    //bosses 
    public GameObject Beetle;
   //world gen
    public int offsetx = 0;
    public int offsetz = 0;
    public int currentbiomecount = 0;
    public int currentdifficultycount = 0;
    public int difficulty = 0;
    public string currentbiome = "";
    public string startingbiome = "Oak";
    public bool isHell = false;
    //etc.
    public bool isArenaMode = false;
    //difficulty and bosses (Progression)
    public int bossspawncounter = 0;
    public float difficultyuptimer = 60;
    public float bossDifficulty = 0;

    //delays itemplacer so there are not major lag spike from multiple tiles loading all at once
    public Queue<int> itemplacerqueue = new Queue<int>();
    private float queuetimer = 0;
    private int previousadded = 0;

    public float amp = 1;
    void Start()
    {
        //random biome chosen to start
        int randomnumber = Random.Range(0, 3);
        if (randomnumber == 0)
            startingbiome = "Oak";
        else if (randomnumber == 1)
            startingbiome = "Pine";
        else 
            startingbiome = "Desert";


        if (isArenaMode == false)
        {
            currentbiome = startingbiome;

            //random offset in noise
            offsetx = Random.Range(0, 999);
            offsetz = Random.Range(0, 999);

            //random amplitude
            amp = Random.Range(5, 15);

            //random special worlds
            //extreme hills world has a 1 in 50 chance of spawning 
            int extremehills = Random.Range(1, 20);
            if (extremehills == 1)
            {
                amp = 20;
            }
            int hellmode = Random.Range(1, 5);
            if (hellmode == 1)
            {
                isHell = true;
            }

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
                bossspawncounter++;
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
        //if player does not travel very far difficulty ramps up every 60 seconds
        if (difficultyuptimer <= 0)
        {
            difficulty++;
            bossspawncounter++;
            currentdifficultycount = 0;
            difficultyuptimer = 60 ;
        }
        else
        {
            difficultyuptimer -= Time.deltaTime;
        }

        if (bossspawncounter >= 2)
        {
            //increases boss difficulty, spawns boss near player
            bossDifficulty++;
            Vector3 playerpostion = GameObject.FindGameObjectWithTag("Player").transform.position;
            GameObject boss = Instantiate(Beetle);
            boss.transform.position = new Vector3(playerpostion.x + 15, playerpostion.y + 15, playerpostion.z);
            bossspawncounter = 0;
        }
    }
    //called by item placer to get a spot in the queue to place objects
    public int requestQueue()
    {
        itemplacerqueue.Enqueue(previousadded + 1);
        previousadded++;
        return previousadded + 1;
    }
}
