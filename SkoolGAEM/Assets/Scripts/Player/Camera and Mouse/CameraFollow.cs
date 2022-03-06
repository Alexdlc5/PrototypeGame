using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    // Update is called once per frame
    void Update()
    {
        //gets the players position and rotation
        Transform playertran = player.transform;
        Quaternion playerrot = playertran.rotation;
        Vector3 playerpos = playertran.position;
        if (RotationInAnyDir(playerrot.eulerAngles.x, playerrot.eulerAngles.z, 20))
        {
            transform.localPosition = new Vector3(transform.localPosition.x, playerrot.eulerAngles.z/ 4, transform.localPosition.z);
            transform.localRotation = Quaternion.Euler(playerrot.eulerAngles.z, transform.localRotation.y, transform.localRotation.z);
        }
        //Vector3 playerlocation = player.transform.position;
        //Vector3 offset = new Vector3(0, -followdistance, followdistance * 2);
        //transform.localPosition = playerlocation + offset;
    }
    bool RotationInAnyDir(float xrot, float zrot, float number)
    {
        float negativerotnum = 360 - number;

        if (xrot >= number && xrot <= negativerotnum || zrot >= number && zrot <= negativerotnum)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
