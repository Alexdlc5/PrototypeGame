using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPlacer : MonoBehaviour
{
    public GameObject Object;
    public float offsetx = 0;
    public float offsetz = 0;
    //sets offsets
    public void setXoff(float x)
    {
        offsetx = x;
    }
    public void setZoff(float z)
    {
        offsetz = z;
    }
    public void setObject(GameObject Object)
    {
        this.Object = Object;
    }
    public void PlaceObjects(int objectcount)
    {
        int layermask = 1 << 6;
        for (int i = 0; i < objectcount; i++)
        {
            Vector3 randomlocation = new Vector3(Random.Range(offsetz - 90, offsetz + 90), 15, Random.Range(offsetx - 90, offsetx + 90));
            transform.position = randomlocation;
            RaycastHit hit;
            Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity, layermask);
            Instantiate(Object, hit.point + Vector3.up - new Vector3(0, 0, 0), transform.rotation);
        }
    }
}
