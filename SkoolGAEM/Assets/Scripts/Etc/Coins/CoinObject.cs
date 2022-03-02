using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinObject : MonoBehaviour
{
    public int value = 1;
    public GameObject coincounter;
    
    void setCounter(GameObject coincounter)
    {
        this.coincounter = coincounter;
    }

    void addCoin()
    {
        coincounter.SendMessage("addCoins", value);
        Destroy(gameObject);
    }

    private float time = 0;
    void Update()
    {
        if (time > 500)
        {
            Destroy(gameObject);
        }
        else
        {
            time += Time.deltaTime;
        }
    }
}
