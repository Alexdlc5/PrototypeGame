using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPlacer : MonoBehaviour
{
    public Transform folder;
    public GameObject Object;
    public Color currentcolor;
    public bool isgrass;
    public float offsetx;
    public float offsetz;
    public bool isspawner = false;
    public float offsety = 0;
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
    public void isGrass(bool isgrass)
    {
        this.isgrass = isgrass;
    }
    public void setObjectColor(Color color)
    {
        currentcolor = color;
    }
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
            Vector3 randomlocation = new Vector3(Random.Range(offsetx, offsetx + 200), 99, Random.Range(offsetz, offsetz + 200));
            transform.position = randomlocation;
            //raycasts for random location down onto mesh and places item ontop of mesh
            RaycastHit hit;
            Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity, layermask);
            //gives object random rotation
            Vector3 newrotation = new Vector3(gameObject.transform.eulerAngles.x, Random.Range(0,360), gameObject.transform.eulerAngles.z);
            transform.rotation = Quaternion.Euler(newrotation);
            //instantiates new object
            GameObject newobject = Instantiate(Object, hit.point + Vector3.up * offsety, transform.rotation);
            //makes a child of another gameobject that will act as a folder
            newobject.SendMessage("setParent", folder);
            //if spawner no need to set visability
            if (!isspawner)
            {
                newobject.SendMessage("setVis", false);
            }
            else
            {
                newobject.SendMessage("setPlayer");
            }

            if (Object.GetComponent<WorldObject>() && Object.GetComponent<WorldObject>().needscolor)
            {
                if (isgrass)
                {
                    //sets mesh to new color
                    MeshRenderer[] meshren = newobject.GetComponentsInChildren<MeshRenderer>();
                    for (i = 0; i < meshren.Length; i++)
                    {
                        meshren[i].material.color = currentcolor;
                    }
                }
                else
                {
                    //sets mesh to new color
                    GetComponent<MeshRenderer>().material.color = currentcolor;
                    newobject.GetComponentInChildren<MeshRenderer>().material.color = currentcolor;
                    //makes rocks random size
                    float scale = Random.Range(1, 5);
                    newobject.transform.localScale = new Vector3(newobject.transform.localScale.x * scale, newobject.transform.localScale.y * scale, newobject.transform.localScale.z * scale);
                }
            }
        }
    }
}
