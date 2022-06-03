using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tree_behavior : MonoBehaviour
{
    public float health = 5;
    public float fallingspeed = 1;
    public float despawntimer = 3;
    private bool falling = false;
    private float random = 0;

    private void Start()
    {
        //random tree falling direction
        random = Random.Range(1, 4);
    }
    // Update is called once per frame
    void Update()
    {
        //once tree is on ground for [despawntimer] seconds despawn
        if (despawntimer <= 0)
        {
            transform.position = transform.position - new Vector3(0,2,0) * Time.deltaTime;
            Destroy(gameObject, 120);
        }
        //if health is zero fall over
        if (health <= 0)
        {
            falling = true;
        }
        //if tree is falling
        if (falling == true && hasfallen() == false)
        {
            //use random float to determine which way the tree falls
            if (random > 3)
            {
                transform.localRotation = transform.localRotation * Quaternion.Euler(new Vector3(fallingspeed,0,0) * Time.deltaTime);
            } 
            else if (random > 2)
            {
                transform.localRotation = transform.localRotation * Quaternion.Euler(new Vector3(-fallingspeed, 0, 0) * Time.deltaTime);
            }
            else if (random > 1)
            {
                transform.localRotation = transform.localRotation * Quaternion.Euler(new Vector3(0, 0, fallingspeed) * Time.deltaTime);
            }
            else if (random > 0)
            {
                transform.localRotation = transform.localRotation * Quaternion.Euler(new Vector3(0, 0, -fallingspeed) * Time.deltaTime);
            }
        } 
        //once tree has fallen
        else if (falling == true && hasfallen() ==  true)
        {
            despawntimer -= Time.deltaTime;
        }
    }
    
    //checks if tree has fallen
    private bool hasfallen()
    {
        if (gameObject.transform.rotation.eulerAngles.x >= 90 && gameObject.transform.rotation.eulerAngles.x <= 270 || gameObject.transform.rotation.eulerAngles.z >= 90 && gameObject.transform.rotation.eulerAngles.z <= 270)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void DealDamage(float damage)
    {
        health -= damage;
    }
}
