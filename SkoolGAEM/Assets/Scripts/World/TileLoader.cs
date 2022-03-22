using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileLoader : MonoBehaviour
{
    public GameObject tile;
    List<Vector2> tilelocations = new List<Vector2>();
    int tilecount = 0;
    private void Start()
    {
        tilelocations.Add(new Vector2(0, 0));
        tilecount ++;
    }
    private void OnTriggerEnter(Collider other)
    {
        //value to offset generated tiles
        float tileoffset = other.GetComponentInParent<Transform>().localScale.x * 10;

        if (other.gameObject.GetComponent<Tile>() == true)
        {
            other.gameObject.GetComponent<Tile>().setInLoadingDistance(true);
        } 
        //checks for world gen hitboxes
        else if (other.gameObject.tag == "North")
        {
            float tilecheck = tilecount;
            //checks thru tilelocations to see if there is a tile in target position
            for (int i = 0; i < tilecount; i++)
            {
                //if coords different
                if (other.GetComponentInParent<Tile>().x != tilelocations[i].x || other.GetComponentInParent<Tile>().z + tileoffset != tilelocations[i].y)
                {
                    tilecheck--;
                }
            }
            //if all coords diffrent
            if (tilecheck == 0)
            {
                //generate new tile
                GameObject newtile = Instantiate(tile);
                Vector3 tilepos = other.GetComponentInParent<Transform>().position;
                float xcoord = tilepos.x;
                float zcoord = tilepos.z + tileoffset;
                newtile.GetComponent<Tile>().setTilePos(xcoord - 40, zcoord - 40);
                tilelocations.Add(new Vector2 (xcoord, zcoord));
            }
            //!PROBLEM WITH VECTOR2s LIST!
            else
            {
                Destroy(other);
            }
        }
        else if (other.gameObject.tag == "South")
        {

        }
        else if (other.gameObject.tag == "East")
        {

        }
        else if (other.gameObject.tag == "West")
        {

        }
    }
    private void OnTriggerExit(Collider other)
    {
        other.gameObject.GetComponent<Tile>().setInLoadingDistance(false);
    }
}
