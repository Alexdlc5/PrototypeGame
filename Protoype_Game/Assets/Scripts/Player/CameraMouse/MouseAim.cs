using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseAim : MonoBehaviour
{
    public Transform player;
    private float sensitivity = SliderValueDisplay.sensitivityvalue;
    private bool isAlive = true;
    //use is reseting to make the y value of the weprot reset when player is balancing 
    void Update()
    {
        if (isAlive)
        {
            float mouseX = Input.GetAxis("Mouse X");
            transform.Rotate(Vector3.up * mouseX * sensitivity * Time.deltaTime, Space.Self);
        }
    }
    public void die ()
    {
        isAlive = false;
    }
    //void FixedUpdate()
    //{
    //    Ray camray = cam.ScreenPointToRay(Input.mousePosition);
    //    Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
    //    float raylength;

    //    if (groundPlane.Raycast(camray, out raylength))
    //    {
    //        Vector3 pointToLook = camray.GetPoint(raylength);
    //        Debug.DrawLine(camray.origin, pointToLook, Color.blue);
    //        transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
    //    }
    //    Vector3 vect = new Vector3(transform.rotation.eulerAngles.x, transform.localRotation.eulerAngles.y, transform.rotation.eulerAngles.z);
    //    transform.localRotation = Quaternion.Euler(vect);
    //}
}
