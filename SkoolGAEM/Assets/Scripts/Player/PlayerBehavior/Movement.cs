using UnityEngine.SceneManagement;
using UnityEngine;
using System;

public class Movement : MonoBehaviour
{
    //add regen?
    public Transform playerrotation;
    public float playerspeed = 0;
    public float accelerationspeed = 0;
    public float tipspeed = 0;
    public float jumppower = 0;
    public float resetmultiplier = 0;
    public float jumptimer = 0;
    public float boosttimer = 0;
    public float inboosttimer = 0;
    public GameObject healthbar;
    public GameObject staminabar;
    public GameObject score;
    public float health = 1;
    public Transform GameObject;
    public Rigidbody rb;

    public int sheildlvl = 0;
    public int boostlvl = 0;
    public int firinglvl = 0;
    public int damagelvl = 0;
    public int speedlvl = 0;

    void FixedUpdate()
    {
        //modifyable version of playerspeed
        float speed = playerspeed;
        speed = speed * (1 + (speedlvl / 5));
        
        //sets initial max speed
        float maxspeed = speed;

        if (inboosttimer > 0)
        {
            maxspeed = speed * (boostlvl + 1) * 500;
        }

        //increments timer
        boosttimer += Time.fixedDeltaTime;

        if (inboosttimer >= 0)
        {
            inboosttimer -= Time.fixedDeltaTime;
        }

        //checks if players health is 0 or less
        if (health <= 0)
        {
            //sends player to death screen
            score.SendMessage("saveScore");
            SceneManager.LoadScene("DeathScreen");
        }

        //rotations
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
                rb.AddForce(-flipped * speed * 100 * Time.fixedDeltaTime);
                
                //boost
                if (Input.GetKeyDown(KeyCode.LeftShift) && boosttimer > 3)
                {
                    rb.AddForce(-flipped * speed * ((boostlvl / 2 + 1) * 5000) * Time.fixedDeltaTime);
                    maxspeed = speed * (boostlvl / 2 + 1) * 5000;
                    boosttimer = 0;
                    inboosttimer = .2f;
                }
            }

            //S key input
            if (Input.GetKey(KeyCode.S))
            {
                //rotates player
                transform.RotateAround(transform.position, playerrotation.right, tipspeed / 200 * Time.fixedDeltaTime);

                //Adds velocity to player
                Vector3 flipped = new Vector3(-(playerrotation.forward.x), playerrotation.forward.y, -(playerrotation.forward.z));
                rb.AddForce(flipped * speed * 100 * Time.fixedDeltaTime);
               
                //boost
                if (Input.GetKeyDown(KeyCode.LeftShift) && boosttimer > 3)
                {
                    rb.AddForce(flipped * speed * ((boostlvl + 1) * 5000) * Time.fixedDeltaTime);
                    maxspeed = speed * (boostlvl + 1) * 5000;
                    boosttimer = 0;
                    inboosttimer = .2f;
                }
            }

            //D key input
            if (Input.GetKey(KeyCode.D))
            {
                //rotates player
                transform.RotateAround(transform.position, playerrotation.forward, tipspeed / 200 * Time.fixedDeltaTime);

                //Adds velocity to player
                Vector3 flipped = new Vector3(-(playerrotation.right.x), playerrotation.right.y, -(playerrotation.right.z));
                rb.AddForce(-flipped * speed * 100 * Time.fixedDeltaTime);
               
                //boost
                if (Input.GetKeyDown(KeyCode.LeftShift) && boosttimer > 3)
                {
                    rb.AddForce(-flipped * speed * ((boostlvl + 1) * 5000) * Time.fixedDeltaTime);
                    maxspeed = speed * (boostlvl + 1) * 5000;
                    boosttimer = 0;
                    inboosttimer = .2f;
                }
            }
            //A key input
            if (Input.GetKey(KeyCode.A))
            {
                //rotates player
                transform.RotateAround(transform.position, playerrotation.forward, -tipspeed / 200 * Time.fixedDeltaTime);

                //Adds velocity to player
                Vector3 flipped = new Vector3(-(playerrotation.right.x), playerrotation.right.y, -(playerrotation.right.z));
                rb.AddForce(flipped * speed * 100 * Time.fixedDeltaTime);
               
                //boost
                if (Input.GetKeyDown(KeyCode.LeftShift) && boosttimer > 3)
                {
                    rb.AddForce(flipped * speed * ((boostlvl + 1) * 5000) * Time.fixedDeltaTime);
                    maxspeed = speed * (boostlvl + 1) * 5000;
                    boosttimer = 0;
                    inboosttimer = .2f;
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
            if (jumptimer >= 1.5f)
            {
                rb.AddForce(Vector3.up * jumppower * 10);
                staminabar.SendMessage("SetSlider", jumptimer);
                balanceX(Xrot);
                balanceZ(Zrot);
                jumptimer = 0;
            }
            else if (jumptimer >= 1f)
            {
                rb.AddForce(Vector3.up * jumppower / 4 * 10);
                staminabar.SendMessage("SetSlider", jumptimer);
                balanceX(Xrot);
                balanceZ(Zrot);
                jumptimer = 0;
            }
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
        //different enemy weapon power lvl tags in future?
        //if player contacts enemy weapon lower health
        if (collision.collider.tag.Equals("EnemyWeapon"))
        {
            DealDamage(1);

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
        
        //updates rotation
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
        //updates rotation
        transform.localRotation = transform.localRotation * Quaternion.Euler(rotationbalanceVector);
    }

    public void setSheildLvl(int lvl)
    {
        sheildlvl = lvl;
    }
    public void setBoostLvl(int lvl)
    {
        boostlvl = lvl;
    }
    public void setFiringLvl(int lvl)
    {
        firinglvl = lvl;
    }
    public void setDamageLvl(int lvl)
    {
        damagelvl = lvl;
    }
    public void setSpeedLvl(int lvl)
    {
        speedlvl = lvl;
    }

    //changed by projectile after collison
    public void DealDamage(float damagedealt)
    {
        health -= damagedealt / (sheildlvl + 1);
        healthbar.SendMessage("SetSlider", health);
    }
    
}