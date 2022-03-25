using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileLoader : MonoBehaviour
{
    public GameObject tile;
    HashSet<Vector2> tilelocations = new HashSet<Vector2>();
    int tilecount = 0;
    private void Start()
    {
        tilelocations.Add(new Vector2(0, 0));
        tilecount ++;
    }
    private void OnTriggerEnter(Collider other)
    {
        //value to offset generated tiles
        float tileoffset = 200;

        if (other.gameObject.GetComponent<Tile>() == true)
        {
            other.gameObject.GetComponent<Tile>().setInLoadingDistance(true);
        } 
        //checks for world gen hitboxes
        else if (other.gameObject.tag == "North")
        {
            //current tile position
            Vector3 tilepos = other.GetComponentsInParent<Transform>()[1].position;
            Destroy(other.gameObject);
            //Debug.Log(tilepos.x.ToString() + ", " + tilepos.y.ToString() + ", " + tilepos.z.ToString());
            //new tile coords
            float xcoord = tilepos.x;
            float zcoord = tilepos.z + tileoffset;
            Vector2 newtileposvector = new Vector2(tilepos.x, tilepos.z + tileoffset);
            
            //if all coords diffrent
            if (!tilelocations.Contains(newtileposvector))
            {
                //generate new tile
                GameObject newtile = Instantiate(tile);
                newtile.GetComponent<Tile>().setTilePos(xcoord, zcoord);
                tilelocations.Add(new Vector2(xcoord, zcoord));
            }
        }
        else if (other.gameObject.tag == "South")
        {
            //current tile position
            Vector3 tilepos = other.GetComponentsInParent<Transform>()[1].position;
            Destroy(other.gameObject);
            //Debug.Log(tilepos.x.ToString() + ", " + tilepos.y.ToString() + ", " + tilepos.z.ToString());
            //new tile coords
            float xcoord = tilepos.x;
            float zcoord = tilepos.z - tileoffset;
            Vector2 newtileposvector = new Vector2(xcoord, zcoord);

            //if all coords diffrent
            if (!tilelocations.Contains(newtileposvector))
            {
                //generate new tile
                GameObject newtile = Instantiate(tile);
                newtile.GetComponent<Tile>().setTilePos(xcoord, zcoord);
                tilelocations.Add(new Vector2(xcoord, zcoord));
            }
        }
        else if (other.gameObject.tag == "East")
        {
            //current tile position
            Vector3 tilepos = other.GetComponentsInParent<Transform>()[1].position;
            Destroy(other.gameObject);
            //Debug.Log(tilepos.x.ToString() + ", " + tilepos.y.ToString() + ", " + tilepos.z.ToString());
            //new tile coords
            float xcoord = tilepos.x + tileoffset;
            float zcoord = tilepos.z;
            Vector2 newtileposvector = new Vector2(xcoord, zcoord);

            //if all coords diffrent
            if (!tilelocations.Contains(newtileposvector))
            {
                //generate new tile
                GameObject newtile = Instantiate(tile);
                newtile.GetComponent<Tile>().setTilePos(xcoord, zcoord);
                tilelocations.Add(new Vector2(xcoord, zcoord));
            }
        }
        else if (other.gameObject.tag == "West")
        {
            //current tile position
            Vector3 tilepos = other.GetComponentsInParent<Transform>()[1].position;
            Destroy(other.gameObject);
            //Debug.Log(tilepos.x.ToString() + ", " + tilepos.y.ToString() + ", " + tilepos.z.ToString());
            //new tile coords
            float xcoord = tilepos.x - tileoffset;
            float zcoord = tilepos.z;
            Vector2 newtileposvector = new Vector2(xcoord, zcoord);

            //if all coords diffrent
            if (!tilelocations.Contains(newtileposvector))
            {
                //generate new tile
                GameObject newtile = Instantiate(tile);
                newtile.GetComponent<Tile>().setTilePos(xcoord, zcoord);
                tilelocations.Add(new Vector2(xcoord, zcoord));
            }
        }
    }
    //need hitbox to cover tile to load and unload tile 
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Tile>())
        {
            other.gameObject.GetComponent<Tile>().setInLoadingDistance(false);
        }
    }
}
