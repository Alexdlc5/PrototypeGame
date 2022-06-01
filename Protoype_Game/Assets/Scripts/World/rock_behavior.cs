using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rock_behavior : MonoBehaviour
{
    //used as identifier in player movement script
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Boss" || collision.gameObject.tag == "BossWeapon")
        {
            Destroy(gameObject);
        }
    }
}
