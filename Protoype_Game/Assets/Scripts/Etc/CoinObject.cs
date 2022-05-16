using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinObject : MonoBehaviour
{
    public int value = 1;
    public GameObject coincounter;
    public GameObject player;
    public Rigidbody rb;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        coincounter = GameObject.FindGameObjectWithTag("CoinCounter");
    }
    public void addCoin()
    {
        coincounter.GetComponent<CoinInv>().addCoins(value);
        Destroy(gameObject, .25f);
    }

    private float time = 0;
    void Update()
    {
        if (time > 5)
        {
            transform.LookAt(player.transform);
            GetComponent<BoxCollider>().enabled = false;
            rb.AddForce(transform.forward * 25);
            addCoin();
        }
        else
        {
            time += Time.deltaTime;
        }
    }
}
