using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPlacer : MonoBehaviour
{
    public Transform folder;
    public GameObject Object;
    public Color currentcolor;
    public float offsetx;
    public bool randomrotation = false;
    public bool randomscale = false;
    public float minscale = 1;
    public float maxscale = 5;
    public float offsetz;
    public bool isspawner = false;
    public float offsety = 0;
    //sets if object will have random rotation
    public void setRandomRotation(bool boolean)
    {
        randomrotation = boolean;
    }
    //set range of the size an object can spawn as
    public void setScaleRange(Vector2 minmax)
    {
        if (minmax == null)
        {
            randomscale = false;
        } 
        else
        {
            minscale = minmax.x;
            maxscale = minmax.y;
            randomscale = true;
        }
    }
    //sets tile and object offsets from 0,0,0
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
    //if object being spawned is spawner 
    public void isSpawner(bool isspawner)
    {
        this.isspawner = isspawner;
    }
    //sets parent in heirarchy
    public void setFolder(Transform folder)
    {
        this.folder = folder;
    }
    //sets object being spawned
    public void setObject(GameObject Object)
    {
        this.Object = Object;
    }
    //sets color
    public void setObjectColor(Color color)
    {
        currentcolor = color;
    }
    //places object/s
    public void PlaceObjects(int objectcount)
    {
        int layermask = 1 << 6;

        if (Object.GetComponent<WorldObject>() && Object.GetComponent<WorldObject>().needscolor)
        {
            //changes the current mesh color to random value
            currentcolor = new Color(Random.Range(1f, 1f), Random.Range(0.6f, 1f), Random.Range(0.0f, 0.00f), 1.0f);
            //values that will hold hue, saturation and brightness value of current color
            float H, S, V;
            Color.RGBToHSV(currentcolor, out H, out S, out V);
            //decreases saturation and brightness
            S -= .4f;
            V -= .5f;
            //set current color with new lower saturation
            currentcolor = Color.HSVToRGB(H, S, V);
        }
        for (int i = 0; i < objectcount; i++)
        {
            //get random location within current tile and moves spanwer to that location
            Vector3 randomlocation = new Vector3(Random.Range(offsetx, offsetx + 190), 99, Random.Range(offsetz, offsetz + 190));
            transform.position = randomlocation;
            //raycasts for random location down onto mesh and places item ontop of mesh
            RaycastHit hit;
            Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity, layermask);
            //gives object random rotation
            if (randomrotation)
            {
                Vector3 newrotation = new Vector3(gameObject.transform.eulerAngles.x, Random.Range(0, 360), gameObject.transform.eulerAngles.z);
                transform.rotation = Quaternion.Euler(newrotation);
            }
            GameObject newobject;
            //instantiates new object
            //checks if item will be placed on ground (prevents props from being spawned on top of each other)
            if ((hit.point + Vector3.up * offsety).y > 15)
            {
                continue;
            } 
            else
            {
                newobject = Instantiate(Object, hit.point + Vector3.up * offsety, transform.rotation);
            }
            //makes a child of another gameobject that will act as a folder
            newobject.GetComponent<WorldObject>().setParent(folder);                          
            //if spawner no need to set visability
            if (!isspawner)
            {
                newobject.GetComponent<WorldObject>().setVis(false);
            }

            if (Object.GetComponent<WorldObject>() && Object.GetComponent<WorldObject>().needscolor)
            {
                GetComponent<MeshRenderer>().material.color = currentcolor;
                //sets mesh to new color
                GetComponent<MeshRenderer>().material.color = currentcolor;
                for (int j = 0; j < newobject.GetComponentsInChildren<MeshRenderer>().Length; j++)
                {
                    newobject.GetComponentsInChildren<MeshRenderer>()[j].material.color = currentcolor;
                }

                //makes rocks random size
                if (randomscale)
                {
                    float scale = Random.Range(minscale, maxscale);
                    newobject.transform.localScale = new Vector3(newobject.transform.localScale.x * scale, newobject.transform.localScale.y * scale, newobject.transform.localScale.z * scale);
                }
            }
        }
    }
}
