using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotationScript : MonoBehaviour
{
    public Transform weapon;
    public float sensitivity = 10f;
    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        weapon.Rotate(Vector3.up * mouseX * sensitivity * Time.deltaTime);
    }
}
