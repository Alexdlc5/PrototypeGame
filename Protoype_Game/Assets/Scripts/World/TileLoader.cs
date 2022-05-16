using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileLoader : MonoBehaviour
{
    public GameObject tile;
    HashSet<Vector2> tilelocations = new HashSet<Vector2>();
    private void Start()
    {
        tilelocations.Add(new Vector2(0, 0));
    }
    private void OnTriggerEnter(Collider other)
    {
        //value to offset generated tiles
        float tileoffset = 200;

        if (other.gameObject.tag == "Tile")
        {
            other.gameObject.GetComponentInParent<Tile>().setInLoadingDistance(true);
        }
        if (other.gameObject.tag == "Spawner")
        {
            other.gameObject.GetComponentInParent<WorldObject>().setVis(true);
        }
        if (other.gameObject.tag == "Prop")
        {
            for (int i = 0; i < other.gameObject.GetComponentsInChildren<MeshRenderer>().Length; i++)
            {
                other.gameObject.GetComponentsInChildren<MeshRenderer>()[i].enabled = true;
            }
        }
        if (other.gameObject.tag == "HealthPickup")
        {
            other.gameObject.GetComponent<MeshRenderer>().enabled = true;
            other.gameObject.GetComponentInChildren<MeshRenderer>().enabled = true;
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
                generateTile(xcoord, zcoord);
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
                generateTile(xcoord, zcoord);
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
                generateTile(xcoord, zcoord);
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
                generateTile(xcoord, zcoord);
            }
        }
        else if (other.gameObject.tag == "WorldOrigin")
        {
            Destroy(other.gameObject);
            GameObject newtile = Instantiate(tile);
            newtile.GetComponent<Tile>().setTilePos(0, 0);
            tilelocations.Add(new Vector2(0, 0));
        }
    }
    //need hitbox to cover tile to load and unload tile 
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Tile")
        {
            other.gameObject.GetComponentInParent<Tile>().setInLoadingDistance(false);
        }
        if (other.gameObject.tag == "Prop")
        {
            for (int i = 0; i < other.gameObject.GetComponentsInChildren<MeshRenderer>().Length; i++)
            {
                other.gameObject.GetComponentsInChildren<MeshRenderer>()[i].enabled = false;
            }
        }
        if (other.gameObject.tag == "HealthPickup")
        {
            other.gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
    }
    void generateTile(float xcoord, float zcoord)
    {
        GameObject newtile = Instantiate(tile);
        newtile.GetComponent<Tile>().setTilePos(xcoord, zcoord);
        tilelocations.Add(new Vector2(xcoord, zcoord));
    }
}
