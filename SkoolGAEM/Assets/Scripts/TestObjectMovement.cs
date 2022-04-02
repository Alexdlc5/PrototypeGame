using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestObjectMovement : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0,0,10);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += new Vector3(0, 0, -10);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(10, 0, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-10, 0, 10);
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            transform.position += new Vector3(0, -10, 0);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            transform.position += new Vector3(0, 10, 0);
        }
    }
}
