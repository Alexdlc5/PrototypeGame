using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    private bool isAlive = true;
    private bool enemylock = false;
    private GameObject LockedEnemy;

    // Update is called once per frame
    void Update()
    {
        if (isAlive)
        {

            //gets the players position and rotation
            Transform playertran = player.transform;
            Quaternion playerrot = playertran.rotation;

            //old following code
            //Vector3 playerlocation = GameObject.FindGameObjectWithTag("Player").transform.position;
            //Vector3 offset = new Vector3(0, -15, 15 * 2);
            //transform.position = playerlocation + offset;
            //transform.rotation = playerrot;

            //creates floats with averages the angles on with z flipped and one with x flipped
            float avgrot = (playerrot.eulerAngles.z + playerrot.eulerAngles.x) / 2;
            float avgrotz = ((360 - playerrot.eulerAngles.z) + playerrot.eulerAngles.x) / 2;
            float avgrotx = (playerrot.eulerAngles.z + (360 - playerrot.eulerAngles.x)) / 2;

            // if (!(playerrot.eulerAngles.z > 20 && playerrot.eulerAngles.z < 340 || playerrot.eulerAngles.x > 20 && playerrot.eulerAngles.x < 340))
            // {
            //if both angles positive
            if (playerrot.eulerAngles.z < 180 && playerrot.eulerAngles.z > 0 && playerrot.eulerAngles.x < 180 && playerrot.eulerAngles.x > 0)
            {
                //changes position and rotation of camera in relation to the player to avoid clipping the ground
                //new Vector3(camera offset right, camera off set up, camera offset back)
                transform.localPosition = new Vector3(3f, avgrot / 25 + 1.5f, -4.5f);
                //Quaternion.Euler(up and down looking angle, sideways rotation, tilt)
                transform.localRotation = Quaternion.Euler(15, 0, 1);
            }
            //only x angle positive 
            else if (playerrot.eulerAngles.x < 180 && playerrot.eulerAngles.x > 0)
            {
                //changes position and rotation of camera in relation to the player to avoid clipping the ground
                transform.localPosition = new Vector3(3f, avgrotz / 25 + 1.5f, -4.5f);
                transform.localRotation = Quaternion.Euler(15, 0, 1);
            }
            //only z angle positive
            else if (playerrot.eulerAngles.z < 180 && playerrot.eulerAngles.z > 0)
            {
                //changes position and rotation of camera in relation to the player to avoid clipping the ground
                transform.localPosition = new Vector3(3f, avgrotx / 25 + 1.5f, -4.5f);
                transform.localRotation = Quaternion.Euler(15, 0, 1);
            }
            //both angles negative
            else //(playerrot.eulerAngles.z >= 180 && playerrot.eulerAngles.z <= 360 && playerrot.eulerAngles.x >= 180 && playerrot.eulerAngles.x <= 360) 
            {
                //changes position and rotation of camera in relation to the player to avoid clipping the ground
                transform.localPosition = new Vector3(3f, (360 - avgrot) / 25 + 1.5f, -4.5f);
                transform.localRotation = Quaternion.Euler(15, 0, 1);
            }
            //} 
        }
        //on death
        else
        {
            enemylock = true;
            //locks on enemy once player is dead (locking on to projectile instead but might keep it)
            if (LockedEnemy != null)
            {
                transform.parent = LockedEnemy.transform;
                Vector3 vector3 = new Vector3(LockedEnemy.transform.position.x, LockedEnemy.transform.position.y, LockedEnemy.transform.position.z);   
                transform.LookAt(vector3);
                transform.position = new Vector3(transform.position.x, transform.position.y + Time.deltaTime * 3, transform.position.z);
            }
        }
    }
    public void die() 
    {
        isAlive = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (enemylock && LockedEnemy == null)
        {
            LockedEnemy = other.gameObject;
        }
    }

}
