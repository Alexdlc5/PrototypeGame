using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StabalizePllatform : MonoBehaviour
{
    public GameObject weapon;
    private void LateUpdate()
    {
        //balances object with y rotation of weapon
        transform.rotation = Quaternion.Euler(0f, weapon.transform.rotation.eulerAngles.y, 0f);
        float Y_transform_delay_percent = .95f;
        transform.localPosition = new Vector3(weapon.transform.position.x, weapon.transform.position.y * Y_transform_delay_percent, weapon.transform.position.z);
    }
}
