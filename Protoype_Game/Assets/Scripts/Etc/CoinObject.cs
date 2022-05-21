using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinObject : MonoBehaviour
{
    public int value = 1;
    public GameObject coincounter;

    private void Start()
    {
        coincounter = GameObject.FindGameObjectWithTag("CoinCounter");
    }
    public void addCoin()
    {
        coincounter.GetComponent<CoinInv>().addCoins(value * 4);
        Destroy(gameObject, .25f);
    }

    private float time = 0;
    void Update()
    {
        if (time > 2)
        {
            GetComponent<BoxCollider>().enabled = false;
            addCoin();
        }
        else
        {
            time += Time.deltaTime;
        }
    }
}
