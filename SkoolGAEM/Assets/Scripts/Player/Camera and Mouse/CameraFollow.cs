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
        //creates floats with averages the angles on with z flipped and one with x flipped
        float avgrot = (playerrot.eulerAngles.z + playerrot.eulerAngles.x) / 2;
        float avgrotz = ((360 - playerrot.eulerAngles.z) + playerrot.eulerAngles.x) / 2;
        float avgrotx = (playerrot.eulerAngles.z + (360 - playerrot.eulerAngles.x)) / 2;
        //mouse input
        float mouseX = Input.GetAxis("Mouse X");
        //if both angle positive
        if (playerrot.eulerAngles.z <= 180 && playerrot.eulerAngles.z >= 0 && playerrot.eulerAngles.x <= 180 && playerrot.eulerAngles.x >= 0)
        {
            //changes position and rotation of camera in relation to the player to avoid clipping the ground
            //new Vector3(camera offset right, camera off set up, camera offset back)
            transform.localPosition = new Vector3(3, avgrot / 10 + 2, -7.15f + avgrot / 5);
            //Quaternion.Euler(up and down looking angle, mouse input, tilt)
            transform.localRotation = Quaternion.Euler(avgrot * 1.25f, mouseX, 1);
        } 
        //only x angle positive 
        else if (playerrot.eulerAngles.x <= 180 && playerrot.eulerAngles.x >= 0)
        {
            //changes position and rotation of camera in relation to the player to avoid clipping the ground
            transform.localPosition = new Vector3(3, avgrotz / 10 + 2, -7.15f + avgrotz / 5);
            transform.localRotation = Quaternion.Euler(avgrotz * 1.25f, mouseX, 1);
        }
        //only z angle positive
        else if (playerrot.eulerAngles.z <= 180 && playerrot.eulerAngles.z >= 0)
        {
            //changes position and rotation of camera in relation to the player to avoid clipping the ground
            transform.localPosition = new Vector3(3, avgrotx / 10 + 2, -7.15f + avgrotx / 5);
            transform.localRotation = Quaternion.Euler(avgrotx * 1.25f, mouseX, 1);
        }
        //both angles negative
        else
        {
            //changes position and rotation of camera in relation to the player to avoid clipping the ground
            transform.localPosition = new Vector3(3, (360 - avgrot) / 10 + 2, -7.15f + (360 - avgrot) / 5);
            transform.localRotation = Quaternion.Euler((360 - avgrot) * 1.25f, mouseX, 1);
        }
        
        //old following code
        //Vector3 playerlocation = player.transform.position;
        //Vector3 offset = new Vector3(0, -followdistance, followdistance * 2);
        //transform.localPosition = playerlocation + offset;
    }
}
