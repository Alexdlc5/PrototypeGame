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
        //is player alive set camera rotation
        if (isAlive)
        {
            transform.localRotation = Quaternion.Euler(9, 0, 1);
        } 
        //on death
        else
        {
            enemylock = true;
            //locks on enemy once player is dead (locking on to projectile instead but might keep it)
            if (LockedEnemy != null)
            {
                //locks on to enemy
                transform.parent = LockedEnemy.transform;
                Vector3 vector3 = new Vector3(LockedEnemy.transform.position.x, LockedEnemy.transform.position.y, LockedEnemy.transform.position.z);   
                transform.LookAt(vector3);
                float Ytransformspeed = 4;
                transform.position = new Vector3(transform.position.x, transform.position.y + Time.deltaTime * Ytransformspeed, transform.position.z);
            }
        }
    }
    //lets camera know when player dies
    public void die() 
    {
        isAlive = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        //locks on to closest enemy 
        if (enemylock && LockedEnemy == null)
        {
            LockedEnemy = other.gameObject;
        }
    }

}
