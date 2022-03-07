using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPlacer : MonoBehaviour
{
    public GameObject Object;
    public int ItemCount = 0;

    void Start()
    {
        for (int i = 0; i < ItemCount; i++)
        {
            Instantiate(Object, new Vector3(Random.Range(0, 900), 15, Random.Range(0, 900)), transform.rotation).SendMessage("freeze");
        }
    }
}
