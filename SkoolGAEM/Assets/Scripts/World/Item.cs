using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    void freeze()
    {
        StartCoroutine(wait());
        Destroy(GetComponent<Rigidbody>());
    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(2);
    }
}
