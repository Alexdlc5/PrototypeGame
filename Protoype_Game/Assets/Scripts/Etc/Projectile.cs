using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public bool isEnemyProjectile = false;
    public float time = 2.5f;
    public float BulletSpeed = 0;
    public GameObject player;
    public float damagelvl = 0;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    // Update is called once per frame
    void Update()
    {
        damagelvl = Movement.damagelvl;
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
        if (collision.gameObject.GetComponent<tree_behavior>())
        {
            GameObject tree = collision.gameObject;
            tree.GetComponent<tree_behavior>().DealDamage(1.0f);
        }
        if (isEnemyProjectile == false)
        {
            if (collision.collider.tag.Equals("Enemy"))
            {
                GameObject enemy = collision.gameObject;
                if (enemy.GetComponent<SimpleEnemy>())
                {
                    //deas damage based on lvl
                    //one added so that when damage lvl == 0, you deal damage
                    enemy.GetComponent<SimpleEnemy>().DealDamage(damagelvl + 1);
                }
                else if (enemy.GetComponent<StalkerEnemy>())
                {
                    enemy.GetComponent<StalkerEnemy>().DealDamage(damagelvl + 1);
                }
                else if (enemy.GetComponent<ShootingEnemy>())
                {
                    enemy.GetComponent<ShootingEnemy>().DealDamage(damagelvl + 1);
                }
            }
            if (collision.collider.tag.Equals("Boss"))
            {
                GameObject enemy = collision.gameObject;
                if (enemy.GetComponent<SimpleBoss>())
                {
                    //deas damage based on lvl
                    //one added so that when damage lvl == 0, you deal damage
                    enemy.GetComponent<SimpleBoss>().DealDamage(damagelvl + 1);
                }
                else if (enemy.GetComponent<SimpleBoss>())
                {
                    enemy.GetComponent<SimpleBoss>().DealDamage(damagelvl + 1);
                }
                else if (enemy.GetComponent<SimpleBoss>())
                {
                    enemy.GetComponent<SimpleBoss>().DealDamage(damagelvl + 1);
                }
            }
        } else
        {
            if (collision.collider.tag.Equals("Player"))
            {
                GameObject enemy = collision.gameObject;
                enemy.GetComponent<Movement>().DealDamage(1.0f);
            }
        }

    }
}
