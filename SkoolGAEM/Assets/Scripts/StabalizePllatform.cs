using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StabalizePllatform : MonoBehaviour
{
    public GameObject weapon;
    void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(0f, weapon.transform.rotation.eulerAngles.y , 0f);
    }
}
