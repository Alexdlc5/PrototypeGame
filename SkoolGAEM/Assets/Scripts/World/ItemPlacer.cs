using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPlacer : MonoBehaviour
{
    public GameObject Object;
    public int ItemCount = 0;

    public void setObject(GameObject Object)
    {
        this.Object = Object;
    }
    public void PlaceObjects()
    {
        int layermask = 1 << 6;
        for (int i = 0; i < ItemCount; i++)
        {
            Vector3 randomlocation = new Vector3(Random.Range(0, 900), 15, Random.Range(0, 900));
            transform.position = randomlocation;
            RaycastHit hit;
            Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity, layermask);
            Instantiate(Object, hit.point + Vector3.up, transform.rotation).SendMessage("freeze");
        }
    }
}
