using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float time = 2.5f;
    public float BulletSpeed = 0;
    // Update is called once per frame
    void Update()
    {
        //projectile only exists for 2.5 secs
        if (time <= 0f)
        {
            Destroy(gameObject);
        } 
        else
        {
            time -= 1 * Time.deltaTime;
        }
       
        //updates position
        Vector3 forward = new Vector3(0.0f, 0.0f, 1.0f);
        transform.position += transform.TransformDirection(forward) * BulletSpeed * Time.deltaTime;
    }
    //when projectile collides with something
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag.Equals("Enemy"))
        {
            GameObject enemy = collision.gameObject;
            enemy.SendMessage("DealDamage", 1.0f);
        }
    }

}
