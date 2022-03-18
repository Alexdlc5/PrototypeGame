using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileLoader : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<Tile>().setInLoadingDistance(true);

    }
    private void OnTriggerExit(Collider other)
    {
        other.gameObject.GetComponent<Tile>().setInLoadingDistance(false);
    }
}
