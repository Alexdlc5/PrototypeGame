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
            //get random location within current tile and moves spanwer to that location
            Vector3 randomlocation = new Vector3(Random.Range(offsetx, offsetx + 200), 99, Random.Range(offsetz, offsetz + 200));
            transform.position = randomlocation;
            //raycasts for random location down onto mesh and places item ontop of mesh
            RaycastHit hit;
            Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity, layermask);
            GameObject newobject = Instantiate(Object, hit.point + Vector3.up * offsety, transform.rotation);
            //makes a child of another gameobject that will act as a folder
            newobject.SendMessage("setParent", folder);
            //if spawner no need to setVis
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
