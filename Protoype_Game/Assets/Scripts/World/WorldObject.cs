using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldObject : MonoBehaviour
{
    public bool needscolor;
    private Transform player_location; 
    public bool setVisOnStart = false;
    public bool visstate = false;
    public bool isenemy = false;
    private float despawntimer = 20;

    private void Start()
    {
        player_location = GameObject.FindGameObjectWithTag("Player").transform;

        if (isenemy)
        {
            setVis(setVisOnStart);
        }
    }

    private void Update()
    {   if (isenemy)
        {
            if (visstate == true)
            {
                despawntimer = 20;
            }
            if (visstate == false)
            {
                despawntimer -= Time.deltaTime;
            }
            if (despawntimer <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
    public void setParent(Transform newparent)
    {
        transform.parent = newparent;
    }
    public void setVis(bool boolean)
    {
        visstate = boolean;
        if (gameObject.GetComponent<MeshRenderer>())
        {
            gameObject.GetComponent<MeshRenderer>().enabled = boolean;
        }
        if (gameObject.GetComponentInChildren<MeshRenderer>())
        {
            for (int i = 0; i < gameObject.GetComponentsInChildren<MeshRenderer>().Length; i++)
            {
                gameObject.GetComponentsInChildren<MeshRenderer>()[i].enabled = boolean;
            }
        }
        else if (gameObject.GetComponentInChildren<MeshRenderer>())
        {
            gameObject.GetComponentInChildren<MeshRenderer>().enabled = !boolean;
        }
    }
}
