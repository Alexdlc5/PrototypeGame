using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class loading : MonoBehaviour
{
    //UI image to obscure intitial tile generation
    public bool intutorial;
    private bool appear = false;
    private float counter = .75f;
    void clear()
    {
        appear = true;
    }
    private void Update()
    {
        if (intutorial)
        {
            appear = true;
        }
        if (appear)
        {
            //fades out 
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
