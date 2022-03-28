using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public bool inloadingdistance = false;
    public float x = 0;
    public float z = 0;
    public void setTilePos(float x, float z)
    {
        this.x = x;
        this.z = z;
        gameObject.GetComponent<MeshGen>().currentcoordsx = x;
        gameObject.GetComponent<MeshGen>().currentcoordsz = z;
        transform.localPosition = new Vector3(x, transform.position.y, z);
    }
    private void Update()
    {
        gameObject.GetComponent<MeshRenderer>().enabled = true;
    }

    public void setInLoadingDistance(bool value)
    {
        inloadingdistance = value;
    }

    //public float getX()
    //{
    //    return x;
    //}
    //public float getZ()
    //{
    //    return z;
    //}

}
