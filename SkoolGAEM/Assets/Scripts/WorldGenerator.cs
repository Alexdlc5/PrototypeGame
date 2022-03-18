using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGenerator : MonoBehaviour
{
    public GameObject tilegenerator;
    private float offsetx = 100;
    private float offsetz = 100;
    MeshGen tile;
    int amp = 0;
    // Start is called before the first frame update
    void Start()
    {
        //random offset in noise
        offsetx = Random.Range(0, 999);
        offsetz = Random.Range(0, 999);

        amp = Random.Range(15, 35);
        tile = tilegenerator.GetComponent<MeshGen>();
        maketile();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void maketile()
    {
        //I tile
        GameObject newtile = Instantiate(tilegenerator);
        newtile.GetComponent<MeshGen>().setAmp(amp);
        newtile.SetActive(true);
        newtile.GetComponent<MeshGen>().GenerateTile(0,0);
        newtile.transform.position = new Vector3(0, 0, 0);
        //II tile
        GameObject netile = Instantiate(tilegenerator);
        netile.GetComponent<MeshGen>().setAmp(amp);
        netile.SetActive(true);
        netile.GetComponent<MeshGen>().GenerateTile(-90f, 0);
        netile.transform.position = new Vector3(900, 0, 0);
    }
}
