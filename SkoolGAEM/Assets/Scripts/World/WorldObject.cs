using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldObject : MonoBehaviour
{
    public bool needscolor;
    public void setParent(Transform newparent)
    {
        transform.parent = newparent;
    }
    public void  setVis(bool boolean)
    {
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
