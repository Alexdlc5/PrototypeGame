using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject projectile;
    public Transform projectilespawn;
    public float delay = 0f;
    public float time = 0.0f;
    
    // Update is called once per frame
    void FixedUpdate()
    {
        time -= 1 * Time.fixedDeltaTime;
        if (Input.GetMouseButton(0))
        {
            if (time <= 0f)
            {
                GameObject newprojectile = Instantiate(projectile, projectilespawn.position, projectilespawn.rotation);
                //projectile ignores collisions with the player
                Physics.IgnoreCollision(newprojectile.GetComponent<Collider>(), GetComponent<Collider>());
                time = delay;
            }
        }
    }
}
