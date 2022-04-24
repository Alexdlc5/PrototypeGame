using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Movement : MonoBehaviour
{
    //add regen?
    public Transform playerrotation;
    public Transform weprot;
    public bool isAlive = true;
    public float playerspeed = 0;
    public float smallobjectscollision = 1;
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
    public GameObject deathoverlay;
    
    public float health;
    private float maxhealth;
    
    public Transform GameObject;
    public Rigidbody rb;

    public static int sheildlvl = 0;
    public static int boostlvl = 0;
    public static int firinglvl = 0;
    public static int damagelvl = 0;
    public static int speedlvl = 0;

    void Start()
    {
        maxhealth = health;
    }

    void FixedUpdate()
    {

        //checks if players health is 0 or less
        if (health <= 0)
        {
            isAlive = false;
            gameObject.GetComponent<Rigidbody>().freezeRotation = false;
            if (Time.timeScale >= 0.0001f)
            {
                Time.timeScale = Time.timeScale - Time.fixedDeltaTime;
            }
            if (deathoverlay.GetComponent<RawImage>().color.a < 1)
            {
                deathoverlay.GetComponent<RawImage>().color = new Color(deathoverlay.GetComponent<RawImage>().color.r, deathoverlay.GetComponent<RawImage>().color.g, deathoverlay.GetComponent<RawImage>().color.b, deathoverlay.GetComponent<RawImage>().color.a + Time.fixedDeltaTime);
            }
            deathoverlay.SetActive(true);
            Time.fixedDeltaTime = Time.timeScale * .02f;
            //sends player to death screen
            //for (int i = 0; i < gameObject.GetComponentsInChildren<MeshRenderer>().Length; i++)
            //{
            //    gameObject.GetComponentsInChildren<MeshRenderer>()[i].enabled = false;
            //}
            score.SendMessage("saveScore");
            //SceneManager.LoadScene("DeathScreen");
        }
        if (isAlive) {
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

            //rotations
            float Xrot = transform.rotation.eulerAngles.x;
            float Zrot = transform.rotation.eulerAngles.z;

            //checks for keyboard input
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
            {
                float currentboostvalue = boostlvl / 3.5f + 1 * 5000;
                //W key input
                if (Input.GetKey(KeyCode.W))
                {
                    //rotates player
                    //rotateX(1);
                    transform.RotateAround(transform.position, playerrotation.right, -tipspeed / 200 * Time.fixedDeltaTime);

                    //creates vector3 with forward direction aligning with the players camera/weapon rotation
                    Vector3 flipped = new Vector3(-(playerrotation.forward.x), playerrotation.forward.y, -(playerrotation.forward.z));

                    //adds velocity to player
                    rb.AddForce(-flipped * speed * 100 * Time.fixedDeltaTime);

                    //boost
                    if (Input.GetKeyDown(KeyCode.LeftShift) && boosttimer > 3)
                    {
                        rb.AddForce(-flipped * speed * currentboostvalue * Time.fixedDeltaTime);
                        maxspeed = speed * currentboostvalue;
                        boosttimer = 0;
                        inboosttimer = .2f;
                    }
                }
                //S key input
                if (Input.GetKey(KeyCode.S))
                {
                    //rotates player
                    //rotateX(0);
                    transform.RotateAround(transform.position, playerrotation.right, tipspeed / 200 * Time.fixedDeltaTime);


                    //Adds velocity to player
                    Vector3 flipped = new Vector3(-(playerrotation.forward.x), playerrotation.forward.y, -(playerrotation.forward.z));
                    rb.AddForce(flipped * speed * 100 * Time.fixedDeltaTime);

                    //boost
                    if (Input.GetKeyDown(KeyCode.LeftShift) && boosttimer > 3)
                    {
                        rb.AddForce(flipped * speed * currentboostvalue * Time.fixedDeltaTime);
                        maxspeed = speed * currentboostvalue;
                        boosttimer = 0;
                        inboosttimer = .2f;
                    }
                }
                //D key input
                if (Input.GetKey(KeyCode.D))
                {
                    //rotates player
                    //rotateZ(0);
                    transform.RotateAround(transform.position, playerrotation.forward, tipspeed / 200 * Time.fixedDeltaTime);

                    //Adds velocity to player
                    Vector3 flipped = new Vector3(-(playerrotation.right.x), playerrotation.right.y, -(playerrotation.right.z));
                    rb.AddForce(-flipped * speed * 100 * Time.fixedDeltaTime);

                    //boost
                    if (Input.GetKeyDown(KeyCode.LeftShift) && boosttimer > 3)
                    {
                        rb.AddForce(-flipped * speed * currentboostvalue * Time.fixedDeltaTime);
                        maxspeed = speed * currentboostvalue;
                        boosttimer = 0;
                        inboosttimer = .2f;
                    }
                }
                //A key input
                if (Input.GetKey(KeyCode.A))
                {;
                    //rotates player
                    //rotateZ(1);
                    transform.RotateAround(transform.position, playerrotation.forward, -tipspeed / 200 * Time.fixedDeltaTime);

                    //Adds velocity to player
                    Vector3 flipped = new Vector3(-(playerrotation.right.x), playerrotation.right.y, -(playerrotation.right.z));
                    rb.AddForce(flipped * speed * 100 * Time.fixedDeltaTime);

                    //boost
                    if (Input.GetKeyDown(KeyCode.LeftShift) && boosttimer > 3)
                    {
                        rb.AddForce(flipped * speed * currentboostvalue * Time.fixedDeltaTime);
                        maxspeed = speed * currentboostvalue;
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
                    rb.AddForce(Vector3.up * jumppower / 2 * 10);
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

            //caps rotation
            if (rb.rotation.eulerAngles.x > 45 && rb.rotation.eulerAngles.x < 315)
            {
                if (360 - rb.rotation.eulerAngles.x > 180)
                {
                    GameObject.transform.rotation = Quaternion.Euler(new Vector3(44.999f, rb.rotation.eulerAngles.y, rb.rotation.eulerAngles.z));
                }
                else
                {
                    GameObject.transform.rotation = Quaternion.Euler(new Vector3(315.001f, rb.rotation.eulerAngles.y, rb.rotation.eulerAngles.z));
                }
            }
            if (rb.rotation.eulerAngles.z > 45 && rb.rotation.eulerAngles.z < 315)
            {
                if (360 - rb.rotation.eulerAngles.z > 180)
                {
                    GameObject.transform.rotation = Quaternion.Euler(new Vector3(rb.rotation.eulerAngles.x, rb.rotation.eulerAngles.y, 44.999f));
                }
                else
                {
                    GameObject.transform.rotation = Quaternion.Euler(new Vector3(rb.rotation.eulerAngles.x, rb.rotation.eulerAngles.y, 315.001f));
                }
            }

            //creates vector3 that is turned into quaternion to reset the y values of the player to 0
            //Vector3 resetYvector3 = new Vector3(transform.localRotation.eulerAngles.x, 0.0f, transform.localRotation.eulerAngles.z);
            //Quaternion resetYquaternion = Quaternion.Euler(resetYvector3);
            //transform.localRotation = resetYquaternion;
        }
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
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<rock_behavior>())
        {
            //when player hits rock, player will be launched up and in the opposite direction their moving by [smallobjectscollision]
            smallobjectscollision = 10f;
            Vector3 changevelocityvector = new Vector3();
            //depending on the direction the player is moving push player out of rock in opposite direction
            if (rb.velocity.x > 0)
            {
                changevelocityvector.x = rb.velocity.x - smallobjectscollision;
            }
            else
            {
                changevelocityvector.x = rb.velocity.x + smallobjectscollision;
            }
            //launch player up
            changevelocityvector.y = rb.velocity.y + smallobjectscollision;
            //depending on the direction the player is moving push player out of rock in opposite direction
            if (rb.velocity.z > 0)
            {
                changevelocityvector.z = rb.velocity.z - smallobjectscollision;
            }
            else
            {
                changevelocityvector.z = rb.velocity.z + smallobjectscollision;
            }
            //apply changes to player velocity
            rb.velocity = changevelocityvector;
        }
        if (other.gameObject.GetComponent<tree_behavior>())
        {
            //when player hits rock, player will be launched up and in the opposite direction their moving by [smallobjectscollision]
            smallobjectscollision = 2f;
            Vector3 changevelocityvector = new Vector3();
            //depending on the direction the player is moving push player out of rock in opposite direction
            if (rb.velocity.x > 0)
            {
                changevelocityvector.x = rb.velocity.x - (rb.velocity.x + smallobjectscollision);
            }
            else
            {
                changevelocityvector.x = rb.velocity.x + (rb.velocity.x + smallobjectscollision);
            }
            changevelocityvector.y = rb.velocity.y;
            //depending on the direction the player is moving push player out of rock in opposite direction
            if (rb.velocity.z > 0)
            {
                changevelocityvector.z = rb.velocity.z - (rb.velocity.x + smallobjectscollision);
            }
            else
            {
                changevelocityvector.z = rb.velocity.z + (rb.velocity.x + smallobjectscollision);
            }
            //apply changes to player velocity
            rb.velocity = changevelocityvector;
        }
        if (other.tag.Equals("HealthPickup"))
        {
            if (health <= maxhealth / 2)
            {
                health = health + (maxhealth / 2);
                healthbar.SendMessage("SetSlider", health);
            }
            else
            {
                health = maxhealth;
                healthbar.SendMessage("SetSlider", health);
            }
            Destroy(other.gameObject);
        }
    }
}