using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class loading : MonoBehaviour
{
    private bool appear = false;
    private float counter = .5f;
    void clear()
    {
        appear = true;
    }
    private void Update()
    {
        if (appear)
        {
            if (counter <= 0)
            {
                if (gameObject.GetComponent<RawImage>().color.a > 0)
                {
                    gameObject.GetComponent<RawImage>().color = new Color(gameObject.GetComponent<RawImage>().color.r, gameObject.GetComponent<RawImage>().color.g, gameObject.GetComponent<RawImage>().color.b, gameObject.GetComponent<RawImage>().color.a - Time.fixedDeltaTime / 1.1f);
                }
                else
                {
                    Destroy(gameObject);
                }
            }
            else
            {
                counter--;
            }
        }
    }
}
