using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldObject : MonoBehaviour
{
    public void setParent(Transform newparent)
    {
        transform.parent = newparent;
    }
    public void  setVis(bool boolean)
    {
        for (int i = 0; i < gameObject.GetComponentsInChildren<MeshRenderer>().Length; i++)
        {
            gameObject.GetComponentsInChildren<MeshRenderer>()[i].enabled = boolean;
        }
    }
}
