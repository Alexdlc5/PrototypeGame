using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    //tile component on every tile
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
        //checks if in loading distance
        gameObject.GetComponent<MeshRenderer>().enabled = inloadingdistance;
    }
    //sets visability
    public void setInLoadingDistance(bool value)
    {
        inloadingdistance = value;
    }
}
