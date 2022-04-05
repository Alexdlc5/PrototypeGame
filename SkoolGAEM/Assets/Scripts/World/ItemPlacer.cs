using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPlacer : MonoBehaviour
{
    public Transform folder;
    public GameObject Object;
    public float offsetx;
    public float offsetz;
    public bool isspawner = false;
    public float offsety = 0;
    //sets offsets
    public void setXoff(float x)
    {
        offsetx = x;
    }
    public void setZoff(float z)
    {
        offsetz = z;
    }
    public void setYoff(float y)
    {
        offsety = y;
    }
    public void isSpawner(bool isspawner)
    {
        this.isspawner = isspawner;
    }
    public void setFolder(Transform folder)
    {
        this.folder = folder;
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
            Vector3 randomlocation = new Vector3(Random.Range(offsetz - 200, offsetz + 200), 99, Random.Range(offsetx - 200, offsetx + 200));
            transform.position = randomlocation;
            RaycastHit hit;
            // hit returning 0,0,0 somtimes, maybe because its missing mesh or maybe direction of cast is wrong, maybe get rid of transform.transformdirection
            Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity, layermask);
            Debug.DrawLine(randomlocation, hit.point, Color.green);
            Debug.Log(hit.point + " ----- " + i);
            GameObject newobject = Instantiate(Object, hit.point + Vector3.up * offsety, transform.rotation);
            newobject.SendMessage("setParent", folder);
            if (!isspawner)
            {
                newobject.SendMessage("setVis", false);
            }
            else
            {
                newobject.SendMessage("setPlayer");
            }
        }
    }
}
