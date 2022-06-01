using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    //projectile
    public GameObject projectile;
    public Transform projectilespawn;
    //timing
    public float delay = 0f;
    public float time = 0.0f;
    //etc
    public GameObject player;
    public float firinglvl = 0;
    
    // Update is called once per frame
    void FixedUpdate()
    {
        firinglvl = Movement.firinglvl;
        float firingdecimal = .75f;
        //firing speed changed by player lvl
        time += (firinglvl / 2f + .5f) * Time.fixedDeltaTime;
        if (Input.GetMouseButton(0))
        {
            if (time >= firingdecimal)
            {
                GameObject newprojectile = Instantiate(projectile, projectilespawn.position, projectilespawn.rotation);
                //projectile ignores collisions with the player
                Physics.IgnoreCollision(newprojectile.GetComponent<Collider>(), GetComponent<Collider>());
                time = delay;
            }
        }
    }
}
