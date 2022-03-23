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
        float tileoffset = 90;

        if (other.gameObject.GetComponent<Tile>() == true)
        {
            other.gameObject.GetComponent<Tile>().setInLoadingDistance(true);
        } 
        //checks for world gen hitboxes
        else if (other.gameObject.tag == "North")
        {
            float tilecheck = tilecount;
            //current tile position
            Vector3 tilepos = other.GetComponentsInParent<Transform>()[1].position;
            Destroy(other.gameObject);
            Debug.Log(tilepos.x.ToString() + ", " + tilepos.y.ToString() + ", " + tilepos.z.ToString());
            //new tile coords
            float xcoord = tilepos.x;
            float zcoord = tilepos.z + tileoffset;
            //checks thru tilelocations to see if there is a tile in target position
            for (int i = 0; i < tilecount; i++)
            {
                //if coords different
                Debug.Log("X: " + xcoord + " : " + tilelocations[i].x);
                Debug.Log("Z: " + zcoord + " : " + tilelocations[i].y);
                if (xcoord != tilelocations[i].x || zcoord != tilelocations[i].y)
                {
                    tilecheck--;
                } 
                else
                {
                    break;
                }
            }
            //if all coords diffrent
            if (tilecheck == 0)
            {
                //generate new tile
                GameObject newtile = Instantiate(tile);
                newtile.GetComponent<Tile>().setTilePos(xcoord, zcoord);
                tilelocations.Add(new Vector2(xcoord, zcoord));
            }
        }
        else if (other.gameObject.tag == "South")
        {
            //might not be set correctly
            float tilecheck = tilecount;
            //current tile position
            Vector3 tilepos = other.GetComponentsInParent<Transform>()[1].position;
            Destroy(other.gameObject);
            Debug.Log(tilepos.x.ToString() + ", " + tilepos.y.ToString() + ", " + tilepos.z.ToString());
            //new tile coords
            float xcoord = tilepos.x;
            float zcoord = tilepos.z - tileoffset;
            //checks thru tilelocations to see if there is a tile in target position
            for (int i = 0; i < tilecount; i++)
            {
                //if coords different
                Debug.Log("X: " + xcoord + " : " + tilelocations[i].x);
                Debug.Log("Z: " + zcoord + " : " + tilelocations[i].y);
                if (xcoord != tilelocations[i].x || zcoord != tilelocations[i].y)
                {
                    tilecheck--;
                } 
                else
                {
                    break;
                }
            }
            //if all coords diffrent
            if (tilecheck == 0)
            {
                //generate new tile
                GameObject newtile = Instantiate(tile);
                newtile.GetComponent<Tile>().setTilePos(xcoord, zcoord);
                tilelocations.Add(new Vector2(xcoord, zcoord));
            }
        }
        //else if (other.gameObject.tag == "East")
        //{
        //    float tilecheck = tilecount;
        //    //current tile position
        //    Vector3 tilepos = other.GetComponentsInParent<Transform>()[1].position;
        //    Destroy(other.gameObject);
        //    //Debug.Log(tilepos.x.ToString() + ", " + tilepos.y.ToString() + ", " + tilepos.z.ToString());
        //    //new tile coords
        //    float xcoord = tilepos.x + tileoffset;
        //    float zcoord = tilepos.z;
        //    //checks thru tilelocations to see if there is a tile in target position
        //    for (int i = 0; i < tilecount; i++)
        //    {
        //        //if coords different
        //        //Debug.Log("X: " + xcoord + " : " + tilelocations[i].x);
        //        //Debug.Log("Z: " + zcoord + " : " + tilelocations[i].y);
        //        if (xcoord != tilelocations[i].x || zcoord != tilelocations[i].y)
        //        {
        //            tilecheck--;
        //        }
        //    }
        //    //if all coords diffrent
        //    if (tilecheck == 0)
        //    {
        //        //generate new tile
        //        GameObject newtile = Instantiate(tile);
        //        newtile.GetComponent<Tile>().setTilePos(xcoord, zcoord);
        //        tilelocations.Add(new Vector2(xcoord, zcoord));
        //    }
        //}
        //else if (other.gameObject.tag == "West")
        //{
        //    float tilecheck = tilecount;
        //    Destroy(other.gameObject);
        //    //current tile position
        //    Vector3 tilepos = other.GetComponentsInParent<Transform>()[1].position;
        //    //Debug.Log(tilepos.x.ToString() + ", " + tilepos.y.ToString() + ", " + tilepos.z.ToString());
        //    //new tile coords
        //    float xcoord = tilepos.x - tileoffset;
        //    float zcoord = tilepos.z;
        //    //checks thru tilelocations to see if there is a tile in target position
        //    for (int i = 0; i < tilecount; i++)
        //    {
        //        //if coords different
        //        //Debug.Log("X: " + xcoord + " : " + tilelocations[i].x);
        //        //Debug.Log("Z: " + zcoord + " : " + tilelocations[i].y);
        //        if (xcoord != tilelocations[i].x || zcoord != tilelocations[i].y)
        //        {
        //            tilecheck--;
        //        }
        //    }
        //    //if all coords diffrent
        //    if (tilecheck == 0)
        //    {
        //        //generate new tile
        //        GameObject newtile = Instantiate(tile);
        //        newtile.GetComponent<Tile>().setTilePos(xcoord, zcoord);
        //        tilelocations.Add(new Vector2(xcoord, zcoord));
        //    }
        //}
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Tile>())
        {
            other.gameObject.GetComponent<Tile>().setInLoadingDistance(false);
        }
    }
}
