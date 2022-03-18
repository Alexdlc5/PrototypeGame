using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public bool inloadingdistance = false;
    private void Update()
    {
       gameObject.GetComponent<MeshRenderer>().enabled = inloadingdistance;
    }

    public void setInLoadingDistance(bool value)
    {
        inloadingdistance = value;
    }

}
