using System.Collections;
using System.Windows.Input;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System;

//***************************************Make Reciol**********************************************
public class Movement : MonoBehaviour
{
    public Transform playerrotation;
    public float playerspeed = 0;
    public float accelerationspeed = 0;
    public float tipspeed = 0;
    public float jumppower = 0;
    public float resetmultiplier = 0;
    public float jumptimer = 0;
    public GameObject healthbar;
    public GameObject staminabar;
    public GameObject score;
    public float health = 1;
    public Transform GameObject;
    public Rigidbody rb;

    void FixedUpdate()
    {
        Boolean boosting = false;
        //checks if players health is 0 or less
        if (health <= 0)
        {
            //sends player to death screen
            score.SendMessage("saveScore");
            SceneManager.LoadScene("DeathScreen");
        }

        //modifyable version of playerspeed
        float speed = playerspeed;

        //creates vectors3 that will be modified then added to rotation
        Vector3 rotationVector = new Vector3(0, 0, 0);

        //new vector3 made for balance
        Vector3 rotationbalanceVector = new Vector3(0, 0, 0);
        float Xrot = transform.rotation.eulerAngles.x;
        float Zrot = transform.rotation.eulerAngles.z;

        //checks for keyboard input
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            //W key input
            if (Input.GetKey(KeyCode.W))
            {
                //rotates player
                transform.RotateAround(transform.position, playerrotation.right, -tipspeed / 200 * Time.fixedDeltaTime);

                //creates vector3 with forward direction aligning with the players camera/weapon rotation
                Vector3 flipped = new Vector3(-(playerrotation.forward.x), playerrotation.forward.y, -(playerrotation.forward.z));
                //adds velocity to player
                if (transform.localRotation.x  >= 30 && transform.localRotation.x <= 330)
                {
                    rb.AddForce(-flipped * speed * 200 * Time.fixedDeltaTime);
                    boosting = true;
                } 
                else
                {
                    rb.AddForce(-flipped * speed * 100 * Time.fixedDeltaTime);
                }
            }
            
            //S key input
            if (Input.GetKey(KeyCode.S))
            {
                //rotates player
                transform.RotateAround(transform.position, playerrotation.right, tipspeed / 200 * Time.fixedDeltaTime);

                //Adds velocity to player
                Vector3 flipped = new Vector3(-(playerrotation.forward.x), playerrotation.forward.y, -(playerrotation.forward.z));
                if (transform.localRotation.z >= 30 && transform.localRotation.z <= 330)
                {
                    rb.AddForce(flipped * speed * 200 * Time.fixedDeltaTime);
                    boosting = true;
                }
                else
                {
                    rb.AddForce(flipped * speed * 100 * Time.fixedDeltaTime);
                }
            }
            
            //D key input
            if (Input.GetKey(KeyCode.D))
            {
                //rotates player
                transform.RotateAround(transform.position, playerrotation.forward, tipspeed / 200 * Time.fixedDeltaTime);

                //Adds velocity to player
                Vector3 flipped = new Vector3(-(playerrotation.right.x), playerrotation.right.y, -(playerrotation.right.z));
                if (transform.localRotation.z >= 30 && transform.localRotation.z <= 330)
                {
                    rb.AddForce(-flipped * speed * 200 * Time.fixedDeltaTime);
                    boosting = true;
                }
                else
                {
                    rb.AddForce(-flipped * speed * 100 * Time.fixedDeltaTime);
                }
            }
            //A key input
            if (Input.GetKey(KeyCode.A))
            {
                //rotates player
                transform.RotateAround(transform.position, playerrotation.forward, -tipspeed / 200 * Time.fixedDeltaTime);

                //Adds velocity to player
                Vector3 flipped = new Vector3(-(playerrotation.right.x), playerrotation.right.y, -(playerrotation.right.z));
                if (transform.localRotation.z >= 30 && transform.localRotation.z <= 330)
                {
                    rb.AddForce(flipped * speed * 200 * Time.fixedDeltaTime);
                    boosting = true;
                }
                else
                {
                    rb.AddForce(flipped * speed * 100 * Time.fixedDeltaTime);
                }
            }
        }
        else
        {
            balanceX(Xrot);
            balanceZ(Zrot);
        }

        //times when you can jump
        if (jumptimer < 5f)
        {
            jumptimer += 1f * Time.fixedDeltaTime;
            staminabar.SendMessage("SetSlider", jumptimer);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            //checks jump timer to see if player should boostjump, hop or not jump at all
            if (jumptimer >= 5f)
            {
                rb.AddForce(Vector3.up * jumppower * 10);
                staminabar.SendMessage("SetSlider", jumptimer);
                balanceX(Xrot);
                balanceZ(Zrot);
                jumptimer = 0;
            }
            else if (jumptimer >= 2f)
            {
                rb.AddForce(Vector3.up * jumppower / 4 * 10);
                staminabar.SendMessage("SetSlider", jumptimer);
                balanceX(Xrot);
                balanceZ(Zrot);
                jumptimer = 0;
            }
        }

        float maxspeed = playerspeed;
        if (boosting == true)
        {
            maxspeed = playerspeed * 3;
        }

        //caps maxspeed
        if (rb.velocity[0] >= maxspeed || rb.velocity[0] <= -maxspeed)
        {
            //if current velocity is at or above maxspeed the velocity is reset to the max speed
            if (rb.velocity[0] >= maxspeed)
            {
                rb.velocity = new Vector3(maxspeed, rb.velocity[1], rb.velocity[2]);
            }
            else
            {
                rb.velocity = new Vector3(-maxspeed, rb.velocity[1], rb.velocity[2]);
            }
        }
        if (rb.velocity[2] >= maxspeed || rb.velocity[2] <= -maxspeed)
        {
            //if current velocity is at or above maxspeed the velocity is reset to the max speed
            if (rb.velocity[2] >= maxspeed)
            {
                rb.velocity = new Vector3(rb.velocity[0], rb.velocity[1], maxspeed);
            }
            else
            {
                rb.velocity = new Vector3(rb.velocity[0], rb.velocity[1], -maxspeed);
            }
        }

        //creates vector3 that is turned into quaternion to reset the y values of the player to 0
        Vector3 resetYvector3 = new Vector3(GameObject.eulerAngles.x, 0.0f, GameObject.eulerAngles.z);
        Quaternion resetYquaternion = Quaternion.Euler(resetYvector3);
        transform.localRotation = resetYquaternion;
    }

    //waits for collision 
    void OnCollisionEnter(Collision collision)
    {
        //if player contacts enemy weapon lower health
        if (collision.collider.tag.Equals("EnemyWeapon"))
        {
            health--;
           
            //sets slider to current health
            healthbar.SendMessage("SetSlider", health);
        }
        //collects coin
        if (collision.collider.tag.Equals("Coin"))
        {
            GameObject coin = collision.gameObject;
            
            //runs addCoin Method in the coinObject;
            coin.SendMessage("addCoin");
        }
    }

    //brings z rotation back to 0
    public void balanceZ(float rot)
    {
        //creates vector3 that will be modifyed
        Vector3 rotationbalanceVector = new Vector3(0, 0, 0);

        //checks angles too see which way the object should tilt to balance 
        if (rot < 360 && rot > 260)
        {
            if (rot > 359f)
            {
                rotationbalanceVector[2] = 0;
            }
            else
            {
                rotationbalanceVector[2] += resetmultiplier * Time.fixedDeltaTime;
            }
        }
        if (rot > 0 && rot < 100)
        {
            if (rot < 1.0f)
            {
                rotationbalanceVector[2] = 0;
            }
            else
            {
                rotationbalanceVector[2] -= resetmultiplier * Time.fixedDeltaTime;
            }
        }
        
        //updates position
        transform.localRotation = transform.localRotation * Quaternion.Euler(rotationbalanceVector);
    }

    //brings x rotation back to 0
    public void balanceX(float rot)
    {
        //creates vector3 that will be modifyed
        Vector3 rotationbalanceVector = new Vector3(0, 0, 0);

        //checks angles too see which way the object should tilt to balance 
        if (rot < 360 && rot > 260)
        {
            if (rot > 359.0f)
            {
                rotationbalanceVector[0] = 0;
            }
            else
            {
                rotationbalanceVector[0] += resetmultiplier * Time.fixedDeltaTime;
            }
        }
        if (rot > 0 && rot < 100)
        {
            if (rot < 1.0f)
            {
                rotationbalanceVector[0] = 0;
            }
            else
            {
                rotationbalanceVector[0] -= resetmultiplier * Time.fixedDeltaTime;
            }
        }
        //updates position
        transform.localRotation = transform.localRotation * Quaternion.Euler(rotationbalanceVector);
    }
}