using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    //public GameObject gun;
    public float followdistance = 20f;
    // Update is called once per frame
    void Update()
    {
        Vector3 playerlocation = player.transform.position;
        Vector3 offset = new Vector3(0, -followdistance, followdistance * 2);
        transform.localPosition = playerlocation + offset;

        //transform.rotation = gun.transform.rotation;
        //Vector3 vectChangedRotation = new Vector3(60f, transform.eulerAngles.y, transform.eulerAngles.z);
        //Quaternion changedrotation = Quaternion.Euler(vectChangedRotation);
        //transform.RotateAround(gun.transform.position, Vector3.up, 3f);

    }
}
