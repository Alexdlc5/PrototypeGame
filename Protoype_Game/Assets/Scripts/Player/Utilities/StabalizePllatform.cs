using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StabalizePllatform : MonoBehaviour
{
    public GameObject weapon;
    void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(0f, weapon.transform.rotation.eulerAngles.y , 0f);
        transform.localPosition = new Vector3(weapon.transform.position.x, weapon.transform.position.y * .95f + 1, weapon.transform.position.z);

    }
}
